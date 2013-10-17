<?php

require_once '../pojos/persona.php';
require_once '../pojos/datoscontacto.php';
require_once '../pojos/pass.php';
require_once '../controladoras/controladorapersonaregioncomuna.php';
require_once '../controladoras/controladoradatoscontacto.php';
require_once '../controladoras/controladorapass.php';

/*
*Contiene la opciones para insertar, listar y modificar
*Personas, Ododntologos, Funcionario, Pacientes
*Opciones:
* 1.- insertar Usuario
* 2.- buscar Usuario por rut
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
			$contacto = new DatosContactos();
			$controladoraContacto = new ControladoraDatosContacto();

			$contacto = $controladoraContacto->buscarPorPersona($idPersona);
			$idPersonaContacto = $contacto->idPersona;
				
			if($idPersonaContacto != 0)
			{
				$arreglo["datosContacto"] = $contacto;
				$arreglo["datosPersona"] = $persona;
			}
		}
		echo(json_encode($arreglo));
	break;
	
}
 
?>