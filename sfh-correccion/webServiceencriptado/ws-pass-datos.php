<?php
require_once '../pojos/pass.php';
require_once '../pojos/datoscontacto.php';
require_once '../controladoras/controladorapass.php';
require_once '../controladoras/controladoradatoscontacto.php';
require_once '../controladoras/encript.php';
/*
*Contiene la opciones para insertar, listar y modificar
*Tratamientos y Abonos
*Opciones:
* 1.- insertar pass
* 2.- Modificar pass
* 3.- Listar pass por idPersona
* 4.- Insertar Datos Contacto
* 5.- Modificar Datos Contacto
* 6.- Listar Datos Contacto id Persona
* 7.- Modificar pass con confirmacion
* 8.- Listar datos Contacto
*/


$jsonRecibido = $_REQUEST["send"];
$encript = new Encript();
$datos = $encript->validarkey($jsonRecibido);
$data = "";
 error_log("json: datos: ".$datos); 
if(!is_numeric($datos))
{
	$data = json_decode($datos);
	$opcion = $data->{"indice"};
}
else
{
	$opcion = -1;	
}
switch ($opcion) 
{
	case 1:
		//json Insertar Pass {"indice":1,"idPersona":3,"pass":"asdasd","fechaCaducidad":"2013-12-12"}
		$idPersona = $data->{'idPersona'};
		$password = $data->{'pass'};
		$fechaCaducidad = $data->{'fechaCaducidad'};
		
		$pass = new Pass();
		$pass->initClass($idPersona,$password,$fechaCaducidad);
		$controladoraPass = new ControladoraPass();
		$arreglo["code"]=1;
		$arreglo["Resultado"] = $controladoraPass->insertarPass($pass);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 2:
		//json Modificar Pass {"indice":2,"idPersona":3,"pass":"asdasd","fechaCaducidad":"2013-08-09"}
		$idPersona = $data->{'idPersona'};
		$password = $data->{'pass'};
		$fechaCaducidad = $data->{'fechaCaducidad'};
		
		$pass = new Pass();
		$pass->initClass($idPersona,$password,$fechaCaducidad);
		$controladoraPass = new ControladoraPass();
		$arreglo["code"]=1;
		$arreglo["Resultado"] = $controladoraPass->modificarPass($pass);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 3:
		//json Listar Pass idPersona {"indice":3,"idPersona":1}
		$idPersona = $data->{"idPersona"};
		$controladoraPass = new ControladoraPass();
		$arreglo["code"] = 3;
		$arreglo["resultado"] =  $controladoraPass->buscarIdPersona($idPersona);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 4:
		//json Insertar Datos Contacto {"indice":4,"idPersona":17,"idComuna":21,"fonoFijo":"+976509346","fonoCelular":"+56984678325","direccion":"San Martin","mail":"ada@gmail.com","fechaIngreso":"2013-10-09"}
		$idPersona = $data->{'idPersona'};
		$idComuna = $data->{'idComuna'};
		$fonoFijo = $data->{'fonoFijo'};
		$fonoCelular = $data->{'fonoCelular'};
		$direccion = $data->{'direccion'};
		$mail = $data->{'mail'};
		$fechaIngreso = $data->{'fechaIngreso'};

		$contacto = new DatosContactos();
		$contacto->initClass($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
		$controladoraDatos = new ControladoraDatosContacto();
		
		$arreglo["code"] = 4;
		$arreglo["Resultado"] = $controladoraDatos->insertarDatosContacto($contacto);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 5:
		//json Modificar Datos Contacto {"indice":5,"idPersona":17,"idComuna":21,"fonoFijo":"+976509346","fonoCelular":"+56984678325","direccion":"San Agustin","mail":"ada@hotmail.com","fechaIngreso":"2013-10-10"}
		$idPersona = $data->{'idPersona'};
		$idComuna = $data->{'idComuna'};
		$fonoFijo = $data->{'fonoFijo'};
		$fonoCelular = $data->{'fonoCelular'};
		$direccion = $data->{'direccion'};
		$mail = $data->{'mail'};
		$fechaIngreso = $data->{'fechaIngreso'};

		$contacto = new DatosContactos();
		$contacto->initClass($idPersona, $idComuna, $fonoFijo, $fonoCelular, $direccion, $mail, $fechaIngreso);
		$controladoraDatos = new ControladoraDatosContacto();
		
		$arreglo["code"] = 5;
		$arreglo["Resultado"] = $controladoraDatos->modificarDatosContacto($contacto);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 6:
		//json Listar Datos Contacto idPersona {"indice":6,"idPersona":17}
		$idPersona = $data->{"idPersona"};
		$controladoraDatos = new ControladoraDatosContacto();
		
		$arreglo["code"] = 6;
		$arreglo["Resultado"] =  $controladoraDatos->buscarPorPersona($idPersona);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
	case 7:
		//json modificar pass {"indice":7,"idPersona":8,"antiguaPass":"asdasd","nuevaPass":"asdcasco"}
		$idPersona = $data->{"idPersona"};
		$contrasena = $data->{"antiguaPass"};
		$nuevaPass = $data->{"nuevaPass"};
		$controladoraPass = new ControladoraPass();
		$passObjeto = new Pass();
		$passObjeto->initClass($idPersona,$contrasena,"null");
		$arreglo["code"] = 7;
		$arreglo["Resultado"] =  $controladoraPass->modificarPassConConfirmacion($passObjeto, $nuevaPass);
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;	
	case 8:
		//json Listar Datos Contacto idPersona {"indice":8}
		$controladoraDatos = new ControladoraDatosContacto();
		$arreglo["code"] = 8;
		$arreglo["Resultado"] =  $controladoraDatos->listarDatosContacto();
		$enript = new Encript();
		$jsonEncriptado = $enript->encriptar($arreglo);
		echo($jsonEncriptado);
	break;
}