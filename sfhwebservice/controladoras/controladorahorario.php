<?php
require_once '../bdmysql/MySqlCon.php'; 
require_once '../pojos/horario.php';
require_once '../pojos/cita.php';
 class ControladoraHorario
{
	private function nameDate($fecha)//formato: 00/00/0000
	{ 	$fecha= empty($fecha)?date('d/m/Y'):$fecha;
		$dias = array('domingo','lunes','martes','miércoles','jueves','viernes','sábado');
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
		   	$sentencia->bind_result($idHorario, $idOdontologo, $dia, $horaInicio, $horaTermino, $modulo ,$nomOdontologo, $appPaternoOdontologo);
        	$indice = 0;

        	while($sentencia->fetch())
        	{
        		$horario = new Horario();
				$horario->initClass($idHorario, $idOdontologo, $horaInicio, $horaTermino,$modulo);
    			$arreglo["idOdontologo"] = $idOdontologo;
    			$arreglo["nomOdontologo"] = $nomOdontologo." ".$appPaternoOdontologo;
    			$arregloHoras = $this->sumaHorario($horaInicio,$modulo,$horaTermino);
    			$arregloCitas = $this->horasTomadas($idOdontologo,$fechaHora[0]);
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
		$fecha= new DateTime($fecha);
		$fecha = $fecha->format("Y-m-d");
		$conexion = new MySqlCon();
		$this->datos ='';
		try
		{
			$this->SqlQuery = '';
			$this->SqlQuery = "SELECT * FROM cita WHERE ID_ODONTOLOGO = ? AND FECHA = ?";
		   	$sentencia=$conexion->prepare($this->SqlQuery);

		   	$sentencia->bind_param("is",$idOdontologo,$fecha);
		   	if($sentencia->execute())
		   	{
		   		$sentencia->bind_result($idCita, $idOdontologo, $idPaciente,$horaInicio, $horaTermino, $fecha, $estado);
		   		$indice=0;
	        	while($sentencia->fetch())
	        	{	
	        		$cita = new Cita();
	        		$cita->initClass($idCita, $idOdontologo, $idPaciente, $horaInicio,$fecha, $estado);
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
		$arregloIndices ="";
		foreach ($arregloFinal as $dato) 
		{
			$numKey = explode("-", array_search($dato, $arregloFinal));
			$arregloIndices = $arregloIndices.$numKey[1].",";
		}
		return $arregloIndices;
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
			//$tiempoHorario--;
		}
		return $arreglosHoras;
	}
}
?>