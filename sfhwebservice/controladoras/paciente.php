<?php

require_once '../controladoras/controladora_paciente.php';
require_once '../pojos/paciente.php';


/*$controladora = new ControladoraPaciente();
$datos = $controladora->listarPacientes(); 
echo(json_encode($datos));*/
$paciente = new Paciente();
$paciente->initClass(2, 8, '2013-02-02');

$controladora = new ControladoraPaciente();
echo ($controladora->eliminarPaciente($paciente));

?>