<?php

//Ejemplo del siguiente JSON
//[{"a":1,"b":2,"c":3,"d":4,"e":5},{"a":10,"b":11,"c":"hola","d":13,"e":14}]



$json = $_REQUEST["opciones"];//Se optiene el JSON por REQUEST (GET o POST)
echo($json);//Se muestra el JSON
$arreglo = json_decode($json);//Se pasa el JSON al arreglo
//echo($arreglo);
echo("<br>".$arreglo[0]->{'a'});// se optiene el valor del json por  indice y luego por campo
echo("<br>".$arreglo[0]->{'b'});
echo("<br>".$arreglo[1]->{'c'});
//En el caso de que solo hubiera sido un JSON asi {"a":1,"b":2,"c":3,"d":4,"e":5}
//se llama de esta forma $arreglo->{'a'}

?>