<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/horario.php';
require_once '../pojos/cita.php';
 class ControladoraHorario
{
	private $SqlQuery;
	private $datos;

	public function listarHorarioOdontologo($idOdontologo)
	{
		$conexion = new MySqlCon();
		$idOdontologoInterno = $idOdontologo;
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM horario WHERE ID_ODONTOLOGO = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("i",$idOdontologoInterno);
        	if($sentencia->execute())
        	{
        		$sentencia->bind_result($idHorario,$idOdontologoConsulta,$dia,$horaInicio, $horaTermino, $duracionModulo);					
				$indice=0;     
				while($sentencia->fetch())
				{
					$horario["idHorario"] = $idHorario;
					$horario["idOdontologoConsulta"] = $idOdontologoConsulta;
					$horario["dia"] = $dia;
					$horario["horaInicio"] = $horaInicio;
					$horario["horaTermino"] = $horaTermino;
					$horario["duracionModulo"] = $duracionModulo;
        			$this->datos[$indice] = $horario;
        			
        			$indice++;
				}
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
        	throw new $e("Error al listar pacientes");
        }
        return $this->datos;
    }
	public function modificarHorario(Horario $horario,$dia)
	{
		$conexion = new MySqlCon();
		$idHorario = $horario->idHorario;
		$idOdontologo = $horario->idOdontologo;
		$diaInterno = $dia;
		$horaInicio = $horario->horaInicio;
		$horaTermino = $horario->horaTermino;
		$duracionModulo = $horario->duracionModulo;
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "UPDATE horario SET ID_ODONTOLOGO = ?, DIA = ?, HORA_INICIO = ?, HORA_TERMINO = ?, DURACION_MODULO = ? WHERE ID_HORARIO = ?;";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("issssi",$idOdontologo,$diaInterno,$horaInicio,$horaTermino,$duracionModulo,$idHorario);
        	if($sentencia->execute())
        	{
        		if($sentencia->affected_rows)
	      		{
		        	$conexion->close();
					return "Modificado";
				}
				else
				{
					$conexion->close();
					return "Error";
				}
        	}
        	else
        	{
        		$conexion->close();
        		return "Error en la coneccion";
        	}
  		}
  		catch(Exception $e)
    	{
        	throw new $e("excepcion");
        	return "error";
        }
        
    	
	}
	public function insertarHorario(Horario $horario,$dia)
	{
		$conexion = new MySqlCon();
		$idOdontologo = $horario->idOdontologo;
		$diaInterno = $dia;
		$horaInicio = $horario->horaInicio;
		$horaTermino = $horario->horaTermino;
		$duracionModulo = $horario->duracionModulo;
		try 
	   	{ 	 
	        $this->SqlQuery='';
	        $this->SqlQuery='INSERT INTO horario (ID_HORARIO, ID_ODONTOLOGO, DIA, HORA_INICIO, HORA_TERMINO, DURACION_MODULO) VALUES (null,  ?,  ?, ?, ?, ?);';
	        $sentencia=$conexion->prepare($this->SqlQuery);
	        $sentencia->bind_param('issss',$idOdontologo,$diaInterno,$horaInicio,$horaTermino,$duracionModulo);
	      	if($sentencia->execute())
	      	{
	        	$conexion->close();
				return $sentencia->insert_id;
			}
			else
			{
				$conexion->close();
	        	return false;
	        }
        }
    	catch(Exception $e)
    	{
         return false;
         throw new $e("Error al Registrar Usuarios");
        }
	}
	private function nameDate($fecha)//formato: 00/00/0000
	{ 	$fecha= empty($fecha)?date('d/m/Y'):$fecha;
		$dias = array('domingo','lunes','martes','miercoles','jueves','viernes','sabado');
		$dd   = explode('/',$fecha);
		$ts   = mktime(0,0,0,$dd[1],$dd[0],$dd[2]);
		return $dias[date('w',$ts)].'/'.date('m',$ts).'/'.date('Y',$ts);
	}

	public function mostrarHorasDisponibles($fecha)
	{

		$conexion = new MySqlCon();
		$fechaHora = explode(" ",$fecha->format('d/m/Y H:i:s'));
		$arregloDia = explode('/', $this->nameDate($fechaHora[0]));
		$nombreDia = $arregloDia[0];
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ho.ID_HORARIO, ho.ID_ODONTOLOGO as IDODONTOLOGO, ho.DIA, ho.HORA_INICIO, ho.HORA_TERMINO, ho.DURACION_MODULO, (select pe.NOMBRE from odontologo od, persona pe where od.ID_ODONTOLOGO = IDODONTOLOGO and od.ID_PERSONA = pe.ID_PERSONA),(select pe.APELLIDO_PATERNO from odontologo od, persona pe where od.ID_ODONTOLOGO = IDODONTOLOGO and od.ID_PERSONA = pe.ID_PERSONA) FROM horario ho WHERE  DIA = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("s",$nombreDia);
		   	$sentencia->execute();
		   	$sentencia->bind_result($idHorario, $idOdontologo, $dia, 
        								$horaInicio, $horaTermino, $modulo ,$nomOdontologo,$appPaternoOdontologo);
        	$indice=0;
        	while($sentencia->fetch())
        	{
        		
        		$horario = new Horario();
				$horario->initClass($idHorario, $idOdontologo, $horaInicio, $horaTermino,$modulo);
    			$arreglo["idOdontologo"] = $idOdontologo;
    			$arreglo["nomOdontologo"] = $nomOdontologo." " . $appPaternoOdontologo;
    			$arregloHoras = $this->sumaHorario($horaInicio,$modulo,$horaTermino);
    			$arregloCitas = $this->horasTomadas($idOdontologo,$fecha);
    			$arreglo["horario"] =	$this->coparHoras($arregloHoras,$arregloCitas);
    			$arreglo["numKeys"] = $this->obtenerkey($arreglo["horario"]);
    			$datos[$indice] =$arreglo;
      			$indice++;
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
    		throw new $e("Error al listar pacientes");
        }
        return $datos;
	}
	public function mostrarHorasDisponiblesWeb($fecha)
	{

		$conexion = new MySqlCon();
		$fechaHora = explode(" ",$fecha->format('d/m/Y H:i:s'));
		$arregloDia = explode('/', $this->nameDate($fechaHora[0]));
		$nombreDia = $arregloDia[0];
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT ho.ID_HORARIO, ho.ID_ODONTOLOGO as IDODONTOLOGO, ho.DIA, ho.HORA_INICIO, ho.HORA_TERMINO, ho.DURACION_MODULO, (select pe.NOMBRE from odontologo od, persona pe where od.ID_ODONTOLOGO = IDODONTOLOGO and od.ID_PERSONA = pe.ID_PERSONA),(select pe.APELLIDO_PATERNO from odontologo od, persona pe where od.ID_ODONTOLOGO = IDODONTOLOGO and od.ID_PERSONA = pe.ID_PERSONA) FROM horario ho WHERE  DIA = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("s",$nombreDia);
		   	$sentencia->execute();
		   	$sentencia->bind_result($idHorario, $idOdontologo, $dia, 
        								$horaInicio, $horaTermino, $modulo ,$nomOdontologo,$appPaternoOdontologo);
        	$indice=0;
        	while($sentencia->fetch())
        	{
        		
        		$horario = new Horario();
				$horario->initClass($idHorario, $idOdontologo, $horaInicio, $horaTermino,$modulo);
    			$arreglo["idOdontologo"] = $idOdontologo;
    			$arreglo["nomOdontologo"] = $nomOdontologo." " . $appPaternoOdontologo;
    			$arregloHoras = $this->sumaHorarioWeb($horaInicio,$modulo,$horaTermino);
    			$arregloCitas = $this->horasTomadas($idOdontologo,$fecha);
    			$arreglo["horario"] =	$this->coparHoras($arregloHoras,$arregloCitas);
    			$datos[$indice] =$arreglo;
      			$indice++;
      		}
       		$conexion->close();
    	}
    	catch(Exception $e)
    	{
    		throw new $e("Error al listar pacientes");
        }
        return $datos;
	}
	public function coparHoras($arregloHoras,$arregloCitas)
	{
		if(!empty($arregloCitas))
		{
			foreach ($arregloCitas as $datos)
			{
				$hora = explode(" ", $datos->horaInicio);
				if(in_array($hora[1],$arregloHoras))
				{
					$key = array_search($hora[1], $arregloHoras);
					unset($arregloHoras[$key]);
				}
				else
				{
					echo "No Existo";
				}
			}	
		}

		return $arregloHoras;
	}
	public function horasTomadas($idOdontologo,$fecha)
	{
		$fechaString =  strlen($fecha+"");
		$conexion = new MySqlCon();
		$this->datos ='';

		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM cita WHERE ID_ODONTOLOGO = ? AND FECHA = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);
		   	$sentencia->bind_param("is",$idOdontologo,$fechaString);
		   	if($sentencia->execute())
		   	{
		   		$sentencia->bind_result($idCita, $idOdontologo, $idPaciente,
		   							 $horaInicio, $horaTermino, $fechaConsulta, $estado);
		   		$indice=0;
	        	while($sentencia->fetch())
	        	{	
	        		$cita = new Cita();
	        		$cita->initClass($idCita, $idOdontologo, $idPaciente, $horaInicio,
	        						 $fechaConsulta, $estado);
	        		$this->datos[$indice] = $cita;
	        		$indice++;
	        	}
		   	}
	    }
	    catch(Exception $e)
    	{

        	throw new $e("Error al listar pacientes");
        }
        return $this->datos;
		
	}
	public function obtenerkey($arregloFinal)
	{
		foreach ($arregloFinal as $dato) 
		{
			$numKey = explode("-", array_search($dato, $arregloFinal));
			$arregloIndices = $arregloIndices.$numKey[1].",";
		}
		return $arregloIndices;
	}
	public function sumaHorarioWeb($fechaInicial, $rangoFecha,$horaTermino)
	{
		$contador=0;
		$contador2=0;
		$arreglosHoras[$contador2]["hora-".$contador] = $fechaInicial;
		$contador2++;
		$contador++;
		list($horaRango,$minRango, $segRango) = explode(":",$rangoFecha);
		while ($fechaInicial!=$horaTermino)
		 {
		 	list($hora,$min, $seg) = explode(":",$fechaInicial);
			$minNuevo = $min + $minRango;
			$horaNueva = $hora+$horaRango;
			if($minNuevo>60)
			{
				$minNuevo = $minNuevo-60;
				$horaNueva = $horaNueva+1;
			}
			else if($minNuevo==60)
			{
				$minNuevo="00";
				$horaNueva = $horaNueva+1;
			}
			if($hora>24)
			{
				$horaNueva= $horaNueva-24;
			}
			if($horaNueva==24)
			{
				$horaNueva="00";
			}
			$fechaInicial = $horaNueva.":".$minNuevo.":".$seg;
			if($fechaInicial!=$horaTermino)
			{
				$arreglosHoras[$contador2]["hora-".$contador] = $fechaInicial;	
			}
			$contador++;
			$contador2++;
			$tiempoHorario--;
		}
		return $arreglosHoras;
//		echo($hora);
	}
	public function sumaHorario($fechaInicial, $rangoFecha,$horaTermino)
	{
		$contador=0;
		$arreglosHoras["hora-".$contador] = $fechaInicial;
		$contador++;
		list($horaRango,$minRango, $segRango) = explode(":",$rangoFecha);
		while ($fechaInicial!=$horaTermino)
		 {
		 	list($hora,$min, $seg) = explode(":",$fechaInicial);
			$minNuevo = $min + $minRango;
			$horaNueva = $hora+$horaRango;
			if($minNuevo>60)
			{
				$minNuevo = $minNuevo-60;
				$horaNueva = $horaNueva+1;
			}
			else if($minNuevo==60)
			{
				$minNuevo="00";
				$horaNueva = $horaNueva+1;
			}
			if($hora>24)
			{
				$horaNueva= $horaNueva-24;
			}
			if($horaNueva==24)
			{
				$horaNueva="00";
			}
			$fechaInicial = $horaNueva.":".$minNuevo.":".$seg;
			if($fechaInicial!=$horaTermino)
			{
				$arreglosHoras["hora-".$contador] = $fechaInicial;	
			}
			$contador++;
			$tiempoHorario--;
		}
		return $arreglosHoras;
//		echo($hora);
	}
	
}
?>