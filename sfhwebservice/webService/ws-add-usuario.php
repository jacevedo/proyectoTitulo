<?php

require_once '../pojos/persona.php';
require_once '../pojos/datoscontacto.php';
require_once '../pojos/pass.php';
require_once '../pojos/comuna.php';
require_once '../controladoras/controladorapersonaregioncomuna.php';
require_once '../controladoras/controladoradatoscontacto.php';
require_once '../controladoras/controladorapass.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Personas, Ododntologos, Funcionario, Pacientes
*Opciones:
* 1.- insertar Usuario
* 2.- buscar Usuario por rut
* 3.- listar Region
* 4.- listar Comuna por Regionç
* 5.- modificar Usuario
* 6.- buscar comuna por id
*/


$jsonRecibido = $_REQUEST["send"];
$data = json_decode($jsonRecibido);
$opcion = $data->{'indice'};

switch ($opcion) 
{
	case 1:
		$arreglo["code"] = 1;
		//json Insertar Usuario {"indice":1,"idPerfil":4,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12","pass":"asdcasco","idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","Direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}
		$idPerfil = $data->{'idPerfil'};
		$rut = $data->{'rut'};
		$dv = $data->{'dv'};
		$nombre = $data->{'nombre'};
		$appPateno = $data->{'appPaterno'};
		$appMaterno = $data->{'appMaterno'};
		$fechaNac = $data->{'fechaNac'};
		$pass = $data->{'pass'};
		$idComuna = $data->{'idComuna'};
		$fonoFijo = $data->{'fonoFijo'};
		$fonoCelular = $data->{'celular'};
		$direccion = $data->{'direccion'};
		$mail = $data->{'mail'};
		$fechaIngreso = $data->{'fechaIngreso'};
		$persona = new Persona();
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$persona->initClass(0, $idPerfil, $rut, $dv, $nombre, $appPateno, $appMaterno, $fechaNac);
		$idPersona = $controladoraPersona->insertarPersona($persona);
		if($idPersona !=-1)
		{
			$pass = new Pass();
			$controladoraPass = new ControladoraPass();
			$pass->initClass($idPersona,$contrasena,"2014-01-01");
			$insertadoPass = $controladoraPass->insertarPass($pass);
			if($insertadoPass=="Password Registrada")
			{
				$datoContacto = new DatosContactos();
				$controladoraContacto = new ControladoraDatosContacto();
				$datoContacto->initClass($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
				if($controladoraContacto->insertarDatosContacto($datoContacto)=="datos Insertados Correctamente")
				{
					$arregloFinal["idPersona"] = $idPersona;
					$arregloFinal["resultado"] = "Todos los datos fueron insertados";
					$arreglo["resultado"] = $arregloFinal; 
				}
				else
				{
					$arregloFinal["idPersona"] = $idPersona;
					$arregloFinal["resultado"] = "Error al insertar los datos de contacto";
					$arreglo["resultado"] = $arregloFinal; 
				}

			}
			else
			{
				$arregloFinal["idPersona"] = $idPersona;
				$arregloFinal["resultado"] = "Hubo un error al registrar la password, comuniquese con la clinica odontologica";
				$arreglo["resultado"] = $arregloFinal; 
			}
		}
		else
		{
			$arreglo["resultado"] = "Hubo un error al ingresar a la persona";
		}

		//Retorna {"idPersonaInsertada":id};	
		echo(json_encode($arreglo));
	break;
	case 2:
		//json Buscar Persona Por Rut {"indice":2,"rut":17897359}
		$rut = $data->{'rut'};

		$persona = new Persona();
		$controladoraPersona = new ControladoraPersonaRegionComuna();

		$arreglo["code"] = 2;
		$persona = $controladoraPersona->buscarPorRutUsuario($rut);
		$idPersona = $persona->idPersona;
	
		if($idPersona != 0)
		{
			$arreglo["datosPersona"] = $persona;

			$contacto = new DatosContactos();
			$controladoraContacto = new ControladoraDatosContacto();

			$contacto = $controladoraContacto->buscarPorPersona($idPersona);
			$idPersonaContacto = $contacto->idPersona;

			if($idPersonaContacto != 0)
			{
				$arreglo["datosContacto"] = $contacto;

				$idComuna = $contacto->idComuna;
				if($idComuna != 0)
				{
					//$datosComuna = new Comuna();
					$controladoraComuna = new ControladoraPersonaRegionComuna();
					$arreglo["datoComuna"] = $controladoraComuna->buscarComunaPorID($idComuna);
				}
				else
				{
					$arreglo["datosComuna"] = "Error";
				}
			}
			else
			{
				$arreglo["datosContacto"] = "No hay datos de contacto";
			}
		}
		echo(json_encode($arreglo));
	break;
	case 3:
		// json listar Regiones {"indice":3}
		$controladoraRegion = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 3;
		$arreglo["listaRegiones"] = $controladoraRegion->listarRegion();
		echo(json_encode($arreglo));
	break;
	case 4:
		// json listar Regiones {"indice":3,"idRegion":13}
		$idRegion = $data->{'idRegion'};
		$controladoraComuna = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 3;
		$arreglo["listaComuna"] = $controladoraComuna->listarComunaPorRegion($idRegion);
		echo(json_encode($arreglo));
	break;
	case 5:
		$arreglo["code"] = 5;
		//json Insertar Usuario {"indice":5,"idPersona":1,"idPerfil":4,"rut":17897359,"dv":2,"nombre":"ada","appPaterno":"wonk","appMaterno":"asturias","fechaNac":"1991-12-12","idComuna":2,"fonoFijo":"0227780184","celular":"+56976087240","direccion":"antonio Varas 666","mail":"asd@asd.com","fechaIngreso":"2013-02-02"}
		$idPersona = $data->{'idPersona'};
		$idPerfil = $data->{'idPerfil'};
		$rut = $data->{'rut'};
		$dv = $data->{'dv'};
		$nombre = $data->{'nombre'};
		$appPaterno = $data->{'appPaterno'};
		$appMaterno = $data->{'appMaterno'};
		$fechaNac = $data->{'fechaNac'};

		$idComuna = $data->{'idComuna'};
		$fonoFijo = $data->{'fonoFijo'};
		$fonoCelular = $data->{'celular'};
		$direccion = $data->{'direccion'};
		$mail = $data->{'mail'};
		$fechaIngreso = $data->{'fechaIngreso'};

		$persona = new Persona();
		$controladoraPersona = new ControladoraPersonaRegionComuna();
		$persona->initClass($idPersona, $idPerfil, $rut, $dv, $nombre, $appPaterno, $appMaterno, $fechaNac);
		$modificado = $controladoraPersona->modificarPersona($persona);
		//$arreglo["resultadoPersona"] = "xDDD";
		if($modificado == "Modificado")
		{
			$arreglo["resultadoPersona"] = "Modificado";

			$cont = new DatosContactos();
			$controladoraContacto = new ControladoraDatosContacto();

			$cont = $controladoraContacto->buscarPorPersona($idPersona);
			$idPersonaContacto = $cont->idPersona;	

			if($idPersonaContacto == 0)
			{
				//$arreglo["resultadoDatos"] = "No Existe Contacto";
				$datoContacto = new DatosContactos();
				$datoContacto->initClass($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
				
				if($controladoraContacto->insertarDatosContacto($datoContacto) == "datos Insertados Correctamente")
				{
					$arreglo["resultadoDatos"] = "Modificado";
				}
				else
				{
					$arreglo["resultadoDatos"] = "Error al modificar datos contacto";
				}
			}
			else
			{
				//$arreglo["resultadoDatos"] = "Existe Contacto";
				$datoContacto = new DatosContactos();
				$datoContacto->initClass($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
				$resultCont = $controladoraContacto->modificarDatosContacto($datoContacto);
				if($resultCont == "Modificado")
				{
					$arreglo["resultadoDatos"] = "Modificado";
				}
				else
				{
					$arreglo["resultadoDatos"] = "Error al modificar datos contacto";
				}
			}
		}
		else
		{
			$arreglo["resultadoPersona"] = "Error al modificar persona";
		}
		echo(json_encode($arreglo));
	break;
	case 6:
		// json listar Regiones {"indice":6,"idComuna":298}
		$idComuna = $data->{'idComuna'};
		$controladoraComuna = new ControladoraPersonaRegionComuna();
		$arreglo["code"] = 3;
		$arreglo["datoComuna"] = $controladoraComuna->buscarComunaPorID($idComuna);
		echo(json_encode($arreglo));
	break;
	
}
 
?>