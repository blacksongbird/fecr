                                  //URL del Proyecto//

var urlconectar = "https://localhost:44359/api/";



                                //Funciones Globales//

function limpiarcampos() {
    $(':input').not(':button, :submit, :reset, :hidden, :checkbox, :radio').val('');
    $(':checkbox, :radio').prop('checked', false);
}

function creadorloader(spanid, titulo) {
    return "<div id='" + spanid + "' style='width: 100vw; height: 100vh; background-color: #55c1FA;'><div class='loader-wrapper'><div class='loader'><div class='roller'></div><div class='roller'></div></div ><div id='loader2' class='loader'><div class='roller'></div><div class='roller'></div></div><div id='loader3' class='loader'><div class='roller'></div><div class='roller'></div></div><br><br><br><br><br><br><h4 style='color:white; margin-left: -100px;'>" + titulo + "...</h4></div>";
}

function habilitarguardar() {
    document.getElementById("btnmodificar").disabled = true;
    document.getElementById("btneliminar").disabled = true;
    document.getElementById("btnguardar").disabled = false;
}

function deshabilitarguardar() {
    document.getElementById("btnmodificar").disabled = false;
    document.getElementById("btneliminar").disabled = false;
    document.getElementById("btnguardar").disabled = true;
}



                        //Ajax de Tablas Sin LLaves Foráneas//



                            //Ajax de Código Comercial//

var CodigoComercial = new Object();
CodigoComercial.Tipo = "";
CodigoComercial.Codigo = "";


//Guardar Código Comercial//

function guardarCodigoComercial(CodigoComercial, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodecodigocomercialguarda' + CodigoComercial.Codigo, 'Guardando Código Comercial ' + CodigoComercial.Codigo);

    $.ajax({
        url: urlconectar + 'CodigoComercial',
        type: 'PUT',
        dataType: 'json',
        data: CodigoComercial,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodecodigocomercialguarda" + data[2]).remove();
            limpiarcampos();
            cargarCodigoComercial(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Código Comercial//

function eliminarCodigoComercial(CodigoComercial, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodecodigocomercialelimina' + CodigoComercial.Codigo, 'Eliminando Código Comercial ' + CodigoComercial.Codigo);

    $.ajax({
        url: urlconectar + 'CodigoComercial',
        type: 'DELETE',
        dataType: 'json',
        data: CodigoComercial,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodecodigocomercialelimina" + data[2]).remove();
            limpiarcampos();
            cargarCodigoComercial(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Código Comercial//

function cargarCodigoComercial(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodecodigocomercialcarga', 'Cargando el listado de Códigos Comerciales');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'CodigoComercial',
        type: 'GET',
        dataType: 'json',
        data: CodigoComercial,
        success: function (data, textStatus, xhr) {

            $("#infodecodigocomercialcarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Tipo1 + '</td><td class="text-left">' + data[indice].Codigo1 + '</td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Tipo1 + '\',\'' + data[indice].Codigo1 + '\')"/></td></tr>';

                }


            }
            else {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Código Comercial a un Select//

function cargarCodigoComercialaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'CodigoComercial',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].Codigo1 + ' value=' + data[indice].Codigo1 + '>' + data[indice].Codigo1 + '</option>';

                }
            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Tipo de Código Comercial a un Select//

function cargarTipoCodigoComercialaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'CodigoComercial',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].Tipo1 + ' value=' + data[indice].Tipo1 + '>' + data[indice].Tipo1 + '</option>';

                }
            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                            //Ajax de Código Tipo Moneda//

var CodigoTipoMoneda = new Object();
CodigoTipoMoneda.CodigoTipo = "";
CodigoTipoMoneda.TipoCambio = "";

//Guardar Código Tipo Moneda//

function guardarCodigoTipoMoneda(CodigoTipoMoneda, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodecodigotipomonedaguarda' + CodigoTipoMoneda.CodigoTipo, 'Guardando Código de Tipo de Moneda ' + CodigoTipoMoneda.CodigoTipo);

    $.ajax({
        url: urlconectar + 'CodigoTipoMoneda',
        type: 'PUT',
        dataType: 'json',
        data: CodigoTipoMoneda,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodecodigotipomonedaguarda" + data[1]).remove();
            limpiarcampos();
            cargarCodigoTipoMoneda(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Código Tipo Moneda//

function eliminarCodigoTipoMoneda(CodigoTipoMoneda, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodecodigotipomonedaelimina' + CodigoTipoMoneda.CodigoTipo, 'Eliminando Código de Tipo de Moneda ' + CodigoTipoMoneda.CodigoTipo);

    $.ajax({
        url: urlconectar + 'CodigoTipoMoneda',
        type: 'DELETE',
        dataType: 'json',
        data: CodigoTipoMoneda,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodecodigotipomonedaelimina" + data[1]).remove();
            limpiarcampos();
            cargarCodigoTipoMoneda(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Código Tipo Moneda//

function modificarCodigoTipoMoneda(CodigoTipoMoneda, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodecodigotipomonedamodifica' + CodigoTipoMoneda.CodigoTipo, 'Modificando Código de Tipo de Moneda ' + CodigoTipoMoneda.CodigoTipo);

    $.ajax({
        url: urlconectar + 'CodigoTipoMoneda',
        type: 'POST',
        dataType: 'json',
        data: CodigoTipoMoneda,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodecodigotipomonedamodifica" + data[1]).remove();
            limpiarcampos();
            cargarCodigoTipoMoneda(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Código Tipo Moneda//

function cargarCodigoTipoMoneda(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodecodigotipomonedacarga', 'Cargando el listado de Códigos de Tipos de Moneda');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'CodigoTipoMoneda',
        type: 'GET',
        dataType: 'json',
        data: CodigoTipoMoneda,
        success: function (data, textStatus, xhr) {

            $("#infodecodigotipomonedacarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Código del Tipo de Moneda</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Cambio</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].CodigoMoneda1 + '</td><td class="text-left">' + data[indice].TipoCambio1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].CodigoMoneda1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Código del Tipo de Moneda</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Cambio</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Código Comercial a un Select//

function cargarCodigoTipoMonedaaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'CodigoTipoMoneda',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].CodigoMoneda1 + ' value=' + data[indice].CodigoMoneda1 + '>' + data[indice].CodigoMoneda1 + '</option>';

                }
            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                    //Ajax de Descuento//

var Descuento = new Object();
Descuento.Monto = "";
Descuento.Naturaleza = "";

//Guardar Descuento//

function guardarDescuento(Descuento, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodedescuentoguarda' + Descuento.Monto, 'Guardando Descuento ' + Descuento.Naturaleza);

    $.ajax({
        url: urlconectar + 'Descuento',
        type: 'PUT',
        dataType: 'json',
        data: Descuento,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodedescuentoguarda" + data[1]).remove();
            limpiarcampos();
            cargarDescuento(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Descuento//

function eliminarDescuento(Descuento, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodedescuentoelimina' + Descuento.Monto, 'Eliminando Descuento ' + Descuento.Naturaleza);

    $.ajax({
        url: urlconectar + 'Descuento',
        type: 'DELETE',
        dataType: 'json',
        data: Descuento,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodedescuentoelimina" + data[1]).remove();
            limpiarcampos();
            cargarDescuento(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Descuento//

function cargarDescuento(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodedescuentocarga', 'Cargando el listado de Descuentos');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Descuento',
        type: 'GET',
        dataType: 'json',
        data: Descuento,
        success: function (data, textStatus, xhr) {

            $("#infodedescuentocarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto del Descuento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Naturaleza</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].MontoDescuento1 + '</td><td class="text-left">' + data[indice].NaturalezaDescuento + '</td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(' + data[indice].MontoDescuento1 + ',\'' + data[indice].NaturalezaDescuento + '\')"/></td></tr>';

                }


            }
            else {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto del Descuento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Naturaleza</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Monto Descuento a un Select//

function cargarMontoDescuentoaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'Descuento',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].MontoDescuento1 + ' value=' + data[indice].MontoDescuento1 + '>' + data[indice].MontoDescuento1 + '</option>';

                }
            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Naturaleza Descuento a un Select//

function cargarNaturalezaDescuentoaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'Descuento',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].NaturalezaDescuento + ' value=' + data[indice].NaturalezaDescuento + '>' + data[indice].NaturalezaDescuento + '</option>';

                }
            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                        //Ajax de Exoneración//

var Exoneracion = new Object();
Exoneracion.TipoDoc = "";
Exoneracion.NumDoc = "";
Exoneracion.NomIns = "";
Exoneracion.FechaEmision = "";
Exoneracion.Porcentaje = "";
Exoneracion.Monto = "";

//Guardar Exoneración//

function guardarExoneracion(Exoneracion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeexoneracionguarda' + Exoneracion.NumDoc, 'Guardando Exoneración ' + Exoneracion.NumDoc);

    $.ajax({
        url: urlconectar + 'Exoneracion',
        type: 'PUT',
        dataType: 'json',
        data: Exoneracion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeexoneracionguarda" + data[2]).remove();
            limpiarcampos();
            cargarExoneracion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Exoneración//

function eliminarExoneracion(Exoneracion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeexoneracionelimina' + Exoneracion.NumDoc, 'Eliminando Exoneración ' + Exoneracion.NumDoc);

    $.ajax({
        url: urlconectar + 'Exoneracion',
        type: 'DELETE',
        dataType: 'json',
        data: Exoneracion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeexoneracionelimina" + data[2]).remove();
            limpiarcampos();
            cargarExoneracion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Exoneración//

function modificarExoneracion(Exoneracion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeexoneracionmodifica' + Exoneracion.NumDoc, 'Modificando Exoneración ' + Exoneracion.NumDoc);

    $.ajax({
        url: urlconectar + 'Exoneracion',
        type: 'POST',
        dataType: 'json',
        data: Exoneracion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeexoneracionmodifica" + data[2]).remove();
            limpiarcampos();
            cargarExoneracion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Exoneración//

function cargarExoneracion(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeexoneracioncarga', 'Cargando el listado de Exoneraciones');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Exoneracion',
        type: 'GET',
        dataType: 'json',
        data: Exoneracion,
        success: function (data, textStatus, xhr) {

            $("#infodeexoneracioncarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Nombre de Institución</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Porcentaje de Exoneración</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto de Exoneración</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].TipoDocumento1 + '</td><td class="text-left">' + data[indice].NumeroDocumento1 + '</td><td class="text-left">' + data[indice].NombreInstitucion1 + '</td><td class="text-left">' + data[indice].FechaEmision1 + '</td><td class="text-left">' + data[indice].PorcentajeExoneracion1 + '</td><td class="text-left">' + data[indice].MontoExoneracion1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].TipoDocumento1 + '\',\'' + data[indice].NumeroDocumento1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Nombre de Institución</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Porcentaje de Exoneración</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto de Exoneración</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Exoneración Para Seleccionar//

function cargarExoneracionParaSeleccionar(espaciomostraravance, iddelatabla) {

    espaciomostraravance.innerHTML += creadorloader('infodeexoneracioncarga', 'Cargando el listado de Exoneraciones');
    document.getElementById(iddelatabla).innerHTML = "";
    $.ajax({
        url: urlconectar + 'Exoneracion',
        type: 'GET',
        dataType: 'json',
        data: Exoneracion,
        success: function (data, textStatus, xhr) {

            $("#infodeexoneracioncarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                exoneracionescargadas = data;
                document.getElementById(iddelatabla).innerHTML += '<thead><tr id="filalistadocabeza' + iddelatabla + '"></tr></thead>';

                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Tipo de Documento</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Número de Documento</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Nombre de Institución</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Porcentaje de Exoneración</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Monto de Exoneración</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Seleccionar</th>';

                document.getElementById(iddelatabla).innerHTML += '<tbody id="listadocuerpo' + iddelatabla + '"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {

                    document.getElementById("listadocuerpo" + iddelatabla).innerHTML += '<tr><td>' + data[indice].TipoDocumento1 + '</td><td>' + data[indice].NumeroDocumento1 + '</td><td>' + data[indice].NombreInstitucion1 + '</td><td>' + data[indice].FechaEmision1 + '</td><td>' + data[indice].PorcentajeExoneracion1 + '</td><td>' + data[indice].MontoExoneracion1 + '</td><td><input type="button" value="Seleccionar" id="btnselecciona" onclick="selectExoneracionLineaDetalle(\'' + data[indice].TipoDocumento1 + '\',\'' + data[indice].NumeroDocumento1 + '\')"/></td></tr>';

                }
                $('#' + iddelatabla).DataTable();


            }
            else {

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                            //Ajax de Identificación//

var Identificacion = new Object();
Identificacion.Numero = "";
Identificacion.Tipo = "";

//Guardar Identificación//

function guardarIdentificacion(Identificacion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeidentificacionguarda' + Identificacion.Numero, 'Guardando Identificación ' + Identificacion.Numero);

    $.ajax({
        url: urlconectar + 'Identificacion',
        type: 'PUT',
        dataType: 'json',
        data: Identificacion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeidentificacionguarda" + data[1]).remove();
            limpiarcampos();
            cargarIdentificacion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Identificación//

function eliminarIdentificacion(Identificacion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeidentificacionelimina' + Identificacion.Numero, 'Eliminando Identificación ' + Identificacion.Numero);

    $.ajax({
        url: urlconectar + 'Identificacion',
        type: 'DELETE',
        dataType: 'json',
        data: Identificacion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeidentificacionelimina" + data[1]).remove();
            limpiarcampos();
            cargarIdentificacion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Identificación//

function modificarIdentificacion(Identificacion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeidentificacionmodifica' + Identificacion.Numero, 'Modificando Identificación ' + Identificacion.Numero);

    $.ajax({
        url: urlconectar + 'Identificacion',
        type: 'POST',
        dataType: 'json',
        data: Identificacion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeidentificacionmodifica" + data[1]).remove();
            limpiarcampos();
            cargarIdentificacion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Identificación//

function cargarIdentificacion(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeidentificacioncarga', 'Cargando el listado de Identificaciones');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Identificacion',
        type: 'GET',
        dataType: 'json',
        data: Identificacion,
        success: function (data, textStatus, xhr) {

            $("#infodeidentificacioncarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Identificación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Identificación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Numero1 + '</td><td class="text-left">' + data[indice].Tipo1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Numero1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Identificación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Identificación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                               //Ajax de Impuesto//

var Impuesto = new Object();
Impuesto.Codigo = "";
Impuesto.CodTarifa = "";
Impuesto.Tarifa = "";
Impuesto.FactorIVA = "";
Impuesto.Monto = "";
Impuesto.MontoExportacion = "";

//Guardar Impuesto//

function guardarImpuesto(Impuesto, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeimpuestoguarda' + Impuesto.Codigo, 'Guardando Impuesto ' + Impuesto.Codigo);

    $.ajax({
        url: urlconectar + 'Impuesto',
        type: 'PUT',
        dataType: 'json',
        data: Impuesto,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeimpuestoguarda" + data[1]).remove();
            limpiarcampos();
            cargarImpuesto(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Impuesto//

function eliminarImpuesto(Impuesto, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeimpuestoelimina' + Impuesto.Codigo, 'Eliminando Impuesto ' + Impuesto.Codigo);

    $.ajax({
        url: urlconectar + 'Impuesto',
        type: 'DELETE',
        dataType: 'json',
        data: Impuesto,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeimpuestoelimina" + data[1]).remove();
            limpiarcampos();
            cargarImpuesto(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Impuesto//

function modificarImpuesto(Impuesto, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeimpuestomodifica' + Impuesto.Codigo, 'Modificando Impuesto ' + Impuesto.Codigo);

    $.ajax({
        url: urlconectar + 'Impuesto',
        type: 'POST',
        dataType: 'json',
        data: Impuesto,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeimpuestomodifica" + data[1]).remove();
            limpiarcampos();
            cargarImpuesto(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Impuesto//

function cargarImpuesto(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeimpuestocarga', 'Cargando el listado de Impuestos');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Impuesto',
        type: 'GET',
        dataType: 'json',
        data: Impuesto,
        success: function (data, textStatus, xhr) {

            $("#infodeimpuestocarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Código de Impuesto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código de Tarifa</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tarifa</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Factor IVA</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto de Impuesto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto de Exportación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Codigo1 + '</td><td class="text-left">' + data[indice].CodigoTarifa1 + '</td><td class="text-left">' + data[indice].Tarifa1 + '</td><td class="text-left">' + data[indice].FactorIVA1 + '</td><td class="text-left">' + data[indice].Monto1 + '</td><td class="text-left">' + data[indice].MontoExportacion1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Codigo1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Código de Impuesto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código de Tarifa</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tarifa</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Factor IVA</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto de Impuesto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto de Exportación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Impuesto Para Seleccionar//

function cargarImpuestoParaSeleccionar(espaciomostraravance, iddelatabla) {

    espaciomostraravance.innerHTML += creadorloader('infodeimpuestocarga', 'Cargando el listado de Impuestos');
    document.getElementById(iddelatabla).innerHTML = "";
    $.ajax({
        url: urlconectar + 'Impuesto',
        type: 'GET',
        dataType: 'json',
        data: Impuesto,
        success: function (data, textStatus, xhr) {

            $("#infodeimpuestocarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                impuestoscargados = data;
                document.getElementById(iddelatabla).innerHTML += '<thead><tr id="filalistadocabeza' + iddelatabla +'"></tr></thead>';

                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Código de Impuesto</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Código de Tarifa</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Tarifa</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Factor IVA</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Monto de Impuesto</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Monto de Exportación</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Seleccionar</th>';


                document.getElementById(iddelatabla).innerHTML += '<tbody class="table-hover" id="listadocuerpo' + iddelatabla + '"></tbody>';

                for (var indice in data) {

                    document.getElementById("listadocuerpo" + iddelatabla).innerHTML += '<tr><td>' + data[indice].Codigo1 + '</td><td>' + data[indice].CodigoTarifa1 + '</td><td>' + data[indice].Tarifa1 + '</td><td>' + data[indice].FactorIVA1 + '</td><td>' + data[indice].Monto1 + '</td><td>' + data[indice].MontoExportacion1 + '</td><td><input type="button" value="Seleccionar" id="btnselecciona" onclick="selectImpuestoLineaDetalle(' + data[indice].Codigo1 + ')"/></td></tr>';

                }
                $('#' + iddelatabla).DataTable();


            }
            else {

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                                //Ajax de TeléfonoFax//

var TelefonoFax = new Object();
TelefonoFax.CodPais = "";
TelefonoFax.NumTel = "";

//Guardar TeléfonoFax//

function guardarTelefonoFax(TelefonoFax, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodetelefonofaxguarda' + TelefonoFax.NumTel, 'Guardando Teléfono o Fax ' + TelefonoFax.NumTel);

    $.ajax({
        url: urlconectar + 'TelefonoFax',
        type: 'PUT',
        dataType: 'json',
        data: TelefonoFax,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodetelefonofaxguarda" + data[1]).remove();
            limpiarcampos();
            cargarTelefonoFax(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar TeléfonoFax//

function eliminarTelefonoFax(TelefonoFax, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodetelefonofaxelimina' + TelefonoFax.NumTel, 'Eliminando Teléfono o Fax ' + TelefonoFax.NumTel);

    $.ajax({
        url: urlconectar + 'TelefonoFax',
        type: 'DELETE',
        dataType: 'json',
        data: TelefonoFax,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodetelefonofaxelimina" + data[1]).remove();
            limpiarcampos();
            cargarTelefonoFax(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar TeléfonoFax//

function modificarTelefonoFax(TelefonoFax, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodetelefonofaxmodifica' + TelefonoFax.NumTel, 'Modificando Teléfono o Fax ' + TelefonoFax.NumTel);

    $.ajax({
        url: urlconectar + 'TelefonoFax',
        type: 'POST',
        dataType: 'json',
        data: TelefonoFax,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodetelefonofaxmodifica" + data[1]).remove();
            limpiarcampos();
            cargarTelefonoFax(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar TeléfonoFax//

function cargarTelefonoFax(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodetelefonofaxcarga', 'Cargando el listado de Teléfonos y Fáxes');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'TelefonoFax',
        type: 'GET',
        dataType: 'json',
        data: TelefonoFax,
        success: function (data, textStatus, xhr) {
            
            $("#infodetelefonofaxcarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();
            
            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Código de País</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Teléfono</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';

                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].CodigoPais1 + '</td><td class="text-left">' + data[indice].NumTelefono1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(' + data[indice].NumTelefono1 + ')"/></td></tr>';

                }

                
            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';
            }
            
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar TeléfonoFax a un Select//

function cargarTelefonoFaxaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'TelefonoFax',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].NumTelefono1 + ' value=' + data[indice].NumTelefono1 + '>' + data[indice].CodigoPais1 + ' ' + data[indice].NumTelefono1 + '</option> ';

                }


            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                                 //Ajax de Ubicación//

var Ubicacion = new Object();
Ubicacion.Provincia = "";
Ubicacion.Canton = "";
Ubicacion.Distrito = "";
Ubicacion.Barrio = "";
Ubicacion.OtrasSenas = "";
Ubicacion.ID = "";

//Guardar Ubicación//

function guardarUbicacion(Ubicacion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeubicacionguarda' + Ubicacion.ID, 'Guardando Ubicación ' + Ubicacion.ID);

    $.ajax({
        url: urlconectar + 'Ubicacion',
        type: 'PUT',
        dataType: 'json',
        data: Ubicacion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeubicacionguarda" + data[1]).remove();
            limpiarcampos();
            cargarUbicacion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Ubicación//

function eliminarUbicacion(Ubicacion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeubicacionelimina' + Ubicacion.ID, 'Eliminando Ubicación ' + Ubicacion.ID);

    $.ajax({
        url: urlconectar + 'Ubicacion',
        type: 'DELETE',
        dataType: 'json',
        data: Ubicacion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeubicacionelimina" + data[1]).remove();
            limpiarcampos();
            cargarUbicacion(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Ubicación//

function modificarUbicacion(Ubicacion, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeubicacionmodifica' + Ubicacion.ID, 'Modificando Ubicación ' + Ubicacion.ID);

    $.ajax({
        url: urlconectar + 'Ubicacion',
        type: 'POST',
        dataType: 'json',
        data: Ubicacion,
        success: function (data, textStatus, xhr) {
            alert(data[0]);
            cargarUbicacion(espaciomostraravance);

            espaciomostraravance.innerHTML += "";
            $("#infodeubicacionmodifica" + data[1]).remove();
            limpiarcampos();
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Ubicación//

function cargarUbicacion(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeubicacioncarga', 'Cargando el listado de Ubicaciones');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Ubicacion',
        type: 'GET',
        dataType: 'json',
        data: Ubicacion,
        success: function (data, textStatus, xhr) {

            $("#infodeubicacioncarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>ID</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Provincia</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Cantón</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Distrito</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Barrio</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Otras Senas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].ID1 + '</td><td class="text-left">' + data[indice].Provincia1 + '</td><td class="text-left">' + data[indice].Canton1 + '</td><td class="text-left">' + data[indice].Distrito1 + '</td><td class="text-left">' + data[indice].Barrio1 + '</td><td class="text-left">' + data[indice].OtrasSenas1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].ID1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>ID</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Provincia</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Cantón</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Distrito</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Barrio</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Otras Senas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Ubicación a un Select//

function cargarUbicacionaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'Ubicacion',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].ID1 + ' value=' + data[indice].Provincia1 + ' ' + data[indice].Barrio1 + '>' + data[indice].Provincia1 + ' ' + data[indice].Canton1 + ' ' + data[indice].Distrito1 + ' ' + data[indice].Barrio1 + ' ' + data[indice].OtrasSenas1 + '</option> ';

                }


            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}




                                                  //Ajax de Tablas Con LLaves Foráneas//



                                                         //Ajax de Detalle Servicio//

var DetalleServicio = new Object();
DetalleServicio.Clave = "";

//Guardar Detalle Servicio//

function guardarDetalleServicio(Factura, DetalleServicio, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodedetalleservicioguarda' + DetalleServicio.Clave, 'Guardando Detalles de Servicio ' + DetalleServicio.Clave);

    $.ajax({
        url: urlconectar + 'DetalleServicio',
        type: 'PUT',
        dataType: 'json',
        data: DetalleServicio,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodedetalleservicioguarda" + data[1]).remove();
            limpiarcampos();
            cargarDetalleServicio(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Detalle Servicio//

function eliminarDetalleServicio(DetalleServicio, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodedetalleservicioelimina' + DetalleServicio.Clave, 'Eliminando Detalles de Servicio ' + DetalleServicio.Clave);

    $.ajax({
        url: urlconectar + 'DetalleServicio',
        type: 'DELETE',
        dataType: 'json',
        data: DetalleServicio,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodedetalleservicioelimina" + data[1]).remove();
            limpiarcampos();
            cargarDetalleServicio(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Detalle Servicio//

function cargarDetalleServicio(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodedetalleserviciocarga', 'Cargando el listado de Detalles de Servicio');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'DetalleServicio',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infodedetalleserviciocarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Clave1.Clave1 + '</td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Clave1.Clave1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Detalle Servicio a un Select//

function cargarDetalleServicioaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'DetalleServicio',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].Clave1.Clave1 + ' value=' + data[indice].Clave1.Clave1 + '>' + data[indice].Clave1.Clave1 + '</option>';

                }


            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                                            //Ajax de Factura//

var Factura = new Object();
Factura.CodActividad = "";
Factura.Clave = "";
Factura.NumConsecutivo = "";
Factura.FechaEmision = "";
Factura.Emisor = "";
Factura.Receptor = "";
Factura.CondVenta = "";
Factura.PlazoCredito = "";
Factura.MedioPago = "";
Factura.LineaDetalleFactura = [];

//Guardar Factura//

function guardarFactura(Factura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodefacturaguarda' + Factura.Clave, 'Guardando Factura ' + Factura.Clave);
    Factura.LineaDetalleFactura = JSON.stringify(Factura.LineaDetalleFactura);
    $.ajax({
        url: urlconectar + 'Factura',
        type: 'PUT',
        dataType: 'json',
        data: Factura,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodefacturaguarda" + data[1]).remove();
            limpiarcampos();
            cargarFactura(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Factura//

function eliminarFactura(Factura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodefacturaelimina' + Factura.Clave, 'Eliminando Factura ' + Factura.Clave);

    $.ajax({
        url: urlconectar + 'Factura',
        type: 'DELETE',
        dataType: 'json',
        data: Factura,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodefacturaelimina" + data[1]).remove();
            limpiarcampos();
            cargarFactura(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Factura//

function modificarFactura(Factura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodefacturamodifica' + Factura.Clave, 'Modificando Factura ' + Factura.Clave);

    $.ajax({
        url: urlconectar + 'Factura',
        type: 'POST',
        dataType: 'json',
        data: Factura,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodefacturamodifica" + data[1]).remove();
            limpiarcampos();
            cargarFactura(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Verificar Factura//

function verificarFactura(Factura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodefacturaverifica' + Factura.Clave, 'Verificando Factura ' + Factura.Clave);

    $.ajax({
        url: urlconectar + 'Factura?id=' + Factura.Clave,
        type: 'GET',
        dataType: 'json',
        data: Factura,
        success: function (data, textStatus, xhr) {
            espaciomostraravance.innerHTML += "";
            $("#infodefacturaverifica" + Factura.Clave).remove();

            switch (data.CodigoActividad1) {

                case "No Existe":
                    {
                        alert("No existen datos con esos parámetros. Ya puede crearlos.");
                        limpiadatosparanuevo();
                        break;
                    }
                case "Error":
                    {
                        alert("Hubo una interrupción en la conexión con la base de datos. Por favor intente de nuevo más tarde.");
                        break;
                    }
                default:
                    {
                        rellenadatosexistentes(data);
                        break;
                    }
            }
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Factura//

function cargarFactura(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodefacturacarga', 'Cargando el listado de Facturas');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Factura',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infodefacturacarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Codigo de Actividad</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número Consecutivo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Emisor</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Receptor</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Condición de Venta</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Plazo de Crédito</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Medio Pago</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Clave1 + '</td><td class="text-left">' + data[indice].CodigoActividad1 + '</td><td class="text-left">' + data[indice].NumeroConsecutivo1 + '</td><td class="text-left">' + data[indice].FechaEmision1 + '</td><td class="text-left">' + data[indice].EmisorPersona1.Nombre1 + '</td><td class="text-left">' + data[indice].ReceptorPersona1.Nombre1 + '</td><td class="text-left">' + data[indice].CondicionVenta1 + '</td><td class="text-left">' + data[indice].PlazoCredito1 + '</td><td class="text-left">' + data[indice].MedioPago1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Clave1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Codigo de Actividad</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número Consecutivo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Emisor</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Receptor</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Condición de Venta</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Plazo de Crédito</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Medio Pago</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Factura a un Select//

function cargarFacturaaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'Factura',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].Clave1 + ' value=' + data[indice].Clave1 + '>' + data[indice].Clave1 + '</option>';

                }


            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}




                                                            //Ajax de Información de Referencia//

var InformacionReferencia = new Object();
InformacionReferencia.TipoDoc = "";
InformacionReferencia.Numero = "";
InformacionReferencia.FechaEmision = "";
InformacionReferencia.Codigo = "";
InformacionReferencia.Razon = "";
InformacionReferencia.Clave = "";

//Guardar Información de Referencia//

function guardarInformacionReferencia(Factura, InformacionReferencia, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeinformacionreferenciaguarda' + InformacionReferencia.Clave, 'Guardando Información de Referencia ' + InformacionReferencia.Clave);

    $.ajax({
        url: urlconectar + 'InformacionReferencia',
        type: 'PUT',
        dataType: 'json',
        data: InformacionReferencia,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeinformacionreferenciaguarda" + data[1]).remove();
            limpiarcampos();
            cargarInformacionReferencia(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Información de Referencia//

function eliminarInformacionReferencia(InformacionReferencia, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeinformacionreferenciaelimina' + InformacionReferencia.Clave, 'Eliminando Información de Referencia ' + InformacionReferencia.Clave);

    $.ajax({
        url: urlconectar + 'InformacionReferencia',
        type: 'DELETE',
        dataType: 'json',
        data: InformacionReferencia,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeinformacionreferenciaelimina" + data[1]).remove();
            limpiarcampos();
            cargarInformacionReferencia(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Información de Referencia//

function modificarInformacionReferencia(InformacionReferencia, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeinformacionreferenciamodifica' + InformacionReferencia.Clave, 'Modificando Información de Referencia ' + InformacionReferencia.Clave);

    $.ajax({
        url: urlconectar + 'InformacionReferencia',
        type: 'POST',
        dataType: 'json',
        data: InformacionReferencia,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeinformacionreferenciamodifica" + data[1]).remove();
            limpiarcampos();
            cargarInformacionReferencia(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Verificar Información de Referencia//

function verificarInformacionReferencia(InformacionReferencia, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeinformacionreferenciaverifica' + InformacionReferencia.Clave, 'Verificando Información de Referencia ' + InformacionReferencia.Clave);

    $.ajax({
        url: urlconectar + 'InformacionReferencia?id=' + InformacionReferencia.Clave,
        type: 'GET',
        dataType: 'json',
        data: InformacionReferencia,
        success: function (data, textStatus, xhr) {
            espaciomostraravance.innerHTML += "";
            $("#infodeinformacionreferenciaverifica" + InformacionReferencia.Clave).remove();

            switch (data.TipoDoc1) {

                case "No Existe":
                    {
                        alert("No existen datos con esos parámetros. Ya puede crearlos.");
                        limpiadatosparanuevo();
                        break;
                    }
                case "Error":
                    {
                        alert("Hubo una interrupción en la conexión con la base de datos. Por favor intente de nuevo más tarde.");
                        break;
                    }
                default:
                    {
                        rellenadatosexistentes(data);
                        break;
                    }
            }
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Información de Referencia//

function cargarInformacionReferencia(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeinformacionreferenciacarga', 'Cargando el listado de Informaciones de Referencia');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'InformacionReferencia',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infodeinformacionreferenciacarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Razón</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Clave1.Clave1 + '</td><td class="text-left">' + data[indice].TipoDoc1 + '</td><td class="text-left">' + data[indice].Numero1 + '</td><td class="text-left">' + data[indice].FechaEmision1 + '</td><td class="text-left">' + data[indice].Codigo1 + '</td><td class="text-left">' + data[indice].Razon1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Clave1.Clave1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Razón</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}


                                                   //Ajax de Línea Detalle//

var LineaDetalle = new Object();
LineaDetalle.NumeroLinea = "";
LineaDetalle.PartidaArancelaria = "";
LineaDetalle.Codigo = "";
LineaDetalle.Cantidad = "";
LineaDetalle.UnidadMedida = "";
LineaDetalle.UnidadMedidaComercial = "";
LineaDetalle.Detalle = "";
LineaDetalle.PrecioUnitario = "";
LineaDetalle.MontoTotal = "";
LineaDetalle.Subtotal = "";
LineaDetalle.BaseImponible = "";
LineaDetalle.ImpuestoNeto = "";
LineaDetalle.MontoTotalLinea = "";
LineaDetalle.Consecutivo = "";
LineaDetalle.MontoDescuento = "";
LineaDetalle.NaturalezaDescuento = "";
LineaDetalle.CodigoComercialTipo = "";
LineaDetalle.CodigoComercialCodigo = "";
LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion = [];


//Guardar Línea Detalle//

function guardarLineaDetalle(LineaDetalle, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodelineadetalleguarda' + LineaDetalle.Consecutivo, 'Guardando Información de Referencia ' + LineaDetalle.Consecutivo);
    LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion = JSON.stringify(LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion);

    $.ajax({
        url: urlconectar + 'LineaDetalle',
        type: 'PUT',
        dataType: 'json',
        data: LineaDetalle,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodelineadetalleguarda" + data[1]).remove();
            limpiarcampos();
            cargarLineaDetalle(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Línea Detalle//

function eliminarLineaDetalle(LineaDetalle, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodelineadetalleelimina' + LineaDetalle.Consecutivo, 'Eliminando Línea Detalle ' + LineaDetalle.Consecutivo);

    $.ajax({
        url: urlconectar + 'LineaDetalle',
        type: 'DELETE',
        dataType: 'json',
        data: LineaDetalle,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodelineadetalleelimina" + data[1]).remove();
            limpiarcampos();
            cargarLineaDetalle(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Línea Detalle//

function modificarLineaDetalle(LineaDetalle, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodelineadetallemodifica' + LineaDetalle.Consecutivo, 'Modificando Línea Detalle ' + LineaDetalle.Consecutivo);

    $.ajax({
        url: urlconectar + 'LineaDetalle',
        type: 'POST',
        dataType: 'json',
        data: LineaDetalle,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodelineadetallemodifica" + data[1]).remove();
            limpiarcampos();
            cargarLineaDetalle(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Verificar Línea Detalle//

function verificarLineaDetalle(LineaDetalle, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodelineadetalleverifica' + LineaDetalle.Consecutivo, 'Verificando Línea Detalle ' + LineaDetalle.Consecutivo);

    $.ajax({
        url: urlconectar + 'LineaDetalle?id=' + LineaDetalle.Consecutivo,
        type: 'GET',
        dataType: 'json',
        data: LineaDetalle,
        success: function (data, textStatus, xhr) {
            espaciomostraravance.innerHTML += "";
            $("#infodelineadetalleverifica" + LineaDetalle.Consecutivo).remove();

            switch (data.PartidaArancelaria1) {

                case "No Existe":
                    {
                        alert("No existen datos con esos parámetros. Ya puede crearlos.");
                        limpiadatosparanuevo();
                        break;
                    }
                case "Error":
                    {
                        alert("Hubo una interrupción en la conexión con la base de datos. Por favor intente de nuevo más tarde.");
                        break;
                    }
                default:
                    {
                        rellenadatosexistentes(data);
                        break;
                    }
            }
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Línea Detalle//

function cargarLineaDetalle(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodelineadetallecarga', 'Cargando el listado de Línea Detalle');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'LineaDetalle',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infodelineadetallecarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Consecutivo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Línea</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Partida Arancelaria</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Cantidad</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Unidad de Medida</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Unidad de Medida Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Detalle</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Precio Unitario</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto Total</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Subtotal</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Base Imponible</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Impuesto Neto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto Total de Línea</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Descuento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Naturaleza del Descuento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Código Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Consecutivo1 + '</td><td class="text-left">' + data[indice].NumeroLinea1 + '</td><td class="text-left">' + data[indice].PartidaArancelaria1 + '</td><td class="text-left">' + data[indice].Codigo1 + '</td><td class="text-left">' + data[indice].Cantidad1 + '</td><td class="text-left">' + data[indice].UnidadMedida1 + '</td><td class="text-left">' + data[indice].UnidadMedidaComercial1 + '</td><td class="text-left">' + data[indice].Detalle1 + '</td><td class="text-left">' + data[indice].PrecioUnitario1 + '</td><td class="text-left">' + data[indice].MontoTotal1 + '</td><td class="text-left">' + data[indice].Subtotal1 + '</td><td class="text-left">' + data[indice].BaseImponible1 + '</td><td class="text-left">' + data[indice].ImpuestoNeto1 + '</td><td class="text-left">' + data[indice].MontoTotalLinea1 + '</td><td class="text-left">' + data[indice].MontoDescuento1.MontoDescuento1 + '</td><td class="text-left">' + data[indice].NaturalezaDescuento.NaturalezaDescuento + '</td><td class="text-left">' + data[indice].CodigoComercialTipo1.Tipo1 + '</td><td class="text-left">' + data[indice].CodigoComercialCodigo1.Codigo1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(' + data[indice].Consecutivo1 + ')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Consecutivo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Línea</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Partida Arancelaria</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Cantidad</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Unidad de Medida</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Unidad de Medida Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Detalle</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Precio Unitario</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto Total</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Subtotal</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Base Imponible</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Impuesto Neto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto Total de Línea</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Descuento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Naturaleza del Descuento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Código Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Línea Detalle Para Seleccionar//

function cargarLineaDetalleParaSeleccionar(espaciomostraravance, iddelatabla) {

    espaciomostraravance.innerHTML += creadorloader('infodelineadetallecarga', 'Cargando el listado de Líneas Detalle');
    document.getElementById(iddelatabla).innerHTML = "";
    $.ajax({
        url: urlconectar + 'LineaDetalle',
        type: 'GET',
        dataType: 'json',
        data: LineaDetalle,
        success: function (data, textStatus, xhr) {

            $("#infodelineadetallecarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById(iddelatabla).innerHTML += '<thead><tr id="filalistadocabeza' + iddelatabla + '"></tr></thead>';

                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Consecutivo</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Cantidad</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Precio Unitario</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Impuesto Neto</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Monto Total de Línea</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Tipo de Código Comercial</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Código Comercial</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Seleccionar</th>';

                document.getElementById(iddelatabla).innerHTML += '<tbody id="listadocuerpo' + iddelatabla + '"></tbody>';

                document.getElementById(iddelatabla).innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo" + iddelatabla).innerHTML += '<tr><td class="text-left">' + data[indice].Consecutivo1 + '</td><td class="text-left">' + data[indice].Cantidad1 + '</td><td class="text-left">' + data[indice].PrecioUnitario1 + '</td><td class="text-left">' + data[indice].ImpuestoNeto1 + '</td><td class="text-left">' + data[indice].MontoTotalLinea1 + '</td>><td class="text-left">' + data[indice].CodigoComercialTipo1.Tipo1 + '</td><td class="text-left">' + data[indice].CodigoComercialCodigo1.Codigo1 + '</td><td class="text-left"><input type="button" value="Seleccionar" id="btnselecciona" onclick="selectLineaDetalleFactura(' + objetoserializadocomillas + ')"/></td></tr>';

                }
                $('#' + iddelatabla).DataTable();


            }
            else {

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                                            //Ajax de Otros//

var Otros = new Object();
Otros.OtroTexto = "";
Otros.OtroContenido = "";
Otros.Clave = "";

//Guardar Otros//

function guardarOtros(Otros, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotrosguarda' + Otros.Clave, 'Guardando Otros ' + Otros.Clave);

    $.ajax({
        url: urlconectar + 'Otros',
        type: 'PUT',
        dataType: 'json',
        data: Otros,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeotrosguarda" + data[1]).remove();
            limpiarcampos();
            cargarOtros(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Otros//

function eliminarOtros(Otros, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotroselimina' + Otros.Clave, 'Eliminando Otros ' + Otros.Clave);

    $.ajax({
        url: urlconectar + 'Otros',
        type: 'DELETE',
        dataType: 'json',
        data: Otros,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeotroselimina" + data[1]).remove();
            limpiarcampos();
            cargarOtros(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Otros//

function modificarOtros(Otros, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotrosmodifica' + Otros.Clave, 'Modificando Otros ' + Otros.Clave);

    $.ajax({
        url: urlconectar + 'Otros',
        type: 'POST',
        dataType: 'json',
        data: Otros,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeotrosmodifica" + data[1]).remove();
            limpiarcampos();
            cargarOtros(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Verificar Otros//

function verificarOtros(Otros, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodepersonaverifica' + Otros.Clave, 'Verificando Otros ' + Otros.Clave);

    $.ajax({
        url: urlconectar + 'Otros?id=' + Otros.Clave,
        type: 'GET',
        dataType: 'json',
        data: Otros,
        success: function (data, textStatus, xhr) {
            espaciomostraravance.innerHTML += "";
            $("#infodepersonaverifica" + Otros.Clave).remove();

            switch (data.OtroTexto1) {

                case "No Existe":
                    {
                        alert("No existen datos con esos parámetros. Ya puede crearlos.");
                        limpiadatosparanuevo();
                        break;
                    }
                case "Error":
                    {
                        alert("Hubo una interrupción en la conexión con la base de datos. Por favor intente de nuevo más tarde.");
                        break;
                    }
                default:
                    {
                        rellenadatosexistentes(data);
                        break;
                    }
            }
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Otros//

function cargarOtros(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotroscarga', 'Cargando el listado de Otros');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Otros',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infodeotroscarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Otro Texto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Otro Contenido</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Clave1.Clave1 + '</td><td class="text-left">' + data[indice].OtroTexto1 + '</td><td class="text-left">' + data[indice].OtroContenido1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Clave1.Clave1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Otro Texto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Otro Contenido</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                                                //Ajax de Otros Cargos//

var OtrosCargos = new Object();
OtrosCargos.TipoDoc = "";
OtrosCargos.NumIdTercero = "";
OtrosCargos.NombreTercero = "";
OtrosCargos.Detalle = "";
OtrosCargos.Porcentaje = "";
OtrosCargos.MontoCargo = "";
OtrosCargos.Clave = "";

//Guardar Otros Cargos//

function guardarOtrosCargos(DetalleServicio, OtrosCargos, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotroscargosguarda' + OtrosCargos.Clave, 'Guardando Otros Cargos ' + OtrosCargos.Clave);

    $.ajax({
        url: urlconectar + 'OtrosCargos',
        type: 'PUT',
        dataType: 'json',
        data: OtrosCargos,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeotroscargosguarda" + data[1]).remove();
            limpiarcampos();
            cargarOtrosCargos(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Otros Cargos//

function eliminarOtrosCargos(OtrosCargos, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotroscargoselimina' + OtrosCargos.Clave, 'Eliminando Otros Cargos ' + OtrosCargos.Clave);

    $.ajax({
        url: urlconectar + 'OtrosCargos',
        type: 'DELETE',
        dataType: 'json',
        data: OtrosCargos,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeotroscargoselimina" + data[1]).remove();
            limpiarcampos();
            cargarOtrosCargos(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Otros Cargos//

function modificarOtrosCargos(DetalleServicio, OtrosCargos, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotroscargosmodifica' + OtrosCargos.Clave, 'Modificando Otros Cargos ' + OtrosCargos.Clave);

    $.ajax({
        url: urlconectar + 'OtrosCargos',
        type: 'POST',
        dataType: 'json',
        data: OtrosCargos,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodeotroscargosmodifica" + data[1]).remove();
            limpiarcampos();
            cargarOtrosCargos(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Verificar Otros Cargos//

function verificarOtrosCargos(OtrosCargos, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotroscargosverifica' + OtrosCargos.Clave, 'Verificando Otros Cargos ' + OtrosCargos.Clave);

    $.ajax({
        url: urlconectar + 'OtrosCargos?id=' + OtrosCargos.Clave,
        type: 'GET',
        dataType: 'json',
        data: OtrosCargos,
        success: function (data, textStatus, xhr) {
            espaciomostraravance.innerHTML += "";
            $("#infodeotroscargosverifica" + OtrosCargos.Clave).remove();

            switch (data.TipoDocumento1) {

                case "No Existe":
                    {
                        alert("No existen datos con esos parámetros. Ya puede crearlos.");
                        limpiadatosparanuevo();
                        break;
                    }
                case "Error":
                    {
                        alert("Hubo una interrupción en la conexión con la base de datos. Por favor intente de nuevo más tarde.");
                        break;
                    }
                default:
                    {
                        rellenadatosexistentes(data);
                        break;
                    }
            }
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Otros Cargos//

function cargarOtrosCargos(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodeotroscargoscarga', 'Cargando el listado de Otros Cargos');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'OtrosCargos',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infodeotroscargoscarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número de Identidad de Tercero</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Nombre de Tercero</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Detalle</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Porcentaje</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Monto del Cargo</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Clave1.Clave1.Clave1 + '</td><td class="text-left">' + data[indice].TipoDocumento1 + '</td><td class="text-left">' + data[indice].NumeroIdentidadTercero1 + '</td><td class="text-left">' + data[indice].NombreTercero1 + '</td><td class="text-left">' + data[indice].Detalle1 + '</td><td class="text-left">' + data[indice].Porcentaje1 + '</td><td class="text-left">' + data[indice].MontoCargo1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Clave1.Clave1.Clave1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Tipo de Documento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Número</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fecha de Emisión</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Razón</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                                                //Ajax de Persona//

var Persona = new Object();
Persona.NombrePersona = "";
Persona.IdentificacionPersona = "";
Persona.NombreComercial = "";
Persona.UbicacionPersona = "";
Persona.TelefonoPersona = "";
Persona.FaxPersona = "";
Persona.CorreoPersona = "";

//Guardar Persona//

function guardarPersona(Identificacion, Persona, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodepersonaguarda' + Persona.IdentificacionPersona, 'Guardando Persona ' + Persona.IdentificacionPersona);

    $.ajax({
        url: urlconectar + 'Identificacion',
        type: 'PUT',
        dataType: 'json',
        data: Identificacion,
        success: function (data, textStatus, xhr) {
            $.ajax({
                url: urlconectar + 'Persona',
                type: 'PUT',
                dataType: 'json',
                data: Persona,
                success: function (data, textStatus, xhr) {
                    alert(data[0]);

                    espaciomostraravance.innerHTML += "";
                    $("#infodepersonaguarda" + data[1]).remove();
                    limpiarcampos();
                    cargarPersona();
                },

                error: function (xhr, textStatus, errorThrown) {
                    alert(xhr);
                    limpiarcampos();
                    espaciomostraravance.innerHTML += "";
                }
            });
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Persona//

function eliminarPersona(Persona, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodepersonaelimina' + Persona.IdentificacionPersona, 'Eliminando Persona ' + Persona.IdentificacionPersona);

    $.ajax({
        url: urlconectar + 'Persona',
        type: 'DELETE',
        dataType: 'json',
        data: Persona,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infodepersonaelimina" + data[1]).remove();
            limpiarcampos();
            cargarPersona();
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Persona//

function modificarPersona(Identificacion, Persona, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodepersonamodifica' + Persona.IdentificacionPersona, 'Modificando Persona ' + Persona.IdentificacionPersona);

    $.ajax({
        url: urlconectar + 'Identificacion',
        type: 'POST',
        dataType: 'json',
        data: Identificacion,
        success: function (data, textStatus, xhr) {
            $.ajax({
                url: urlconectar + 'Persona',
                type: 'POST',
                dataType: 'json',
                data: Persona,
                success: function (data, textStatus, xhr) {
                    alert(data[0]);

                    espaciomostraravance.innerHTML += "";
                    $("#infodepersonamodifica" + data[1]).remove();
                    limpiarcampos();
                    cargarPersona();
                },

                error: function (xhr, textStatus, errorThrown) {
                    alert(xhr);
                    limpiarcampos();
                    espaciomostraravance.innerHTML += "";
                }
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });
}

//Verificar Persona//

function verificarPersona(Persona, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodepersonaverifica' + Persona.IdentificacionPersona, 'Verificando Persona ' + Persona.IdentificacionPersona);

    $.ajax({
        url: urlconectar + 'Persona?id=' + Persona.IdentificacionPersona,
        type: 'GET',
        dataType: 'json',
        data: Persona,
        success: function (data, textStatus, xhr) {
            espaciomostraravance.innerHTML += "";
            $("#infodepersonaverifica" + Persona.IdentificacionPersona).remove();

            switch (data.Nombre1) {

                case "No Existe":
                    {
                        alert("No existen datos con esos parámetros. Ya puede crearlos.");
                        limpiadatosparanuevo();
                        break;
                    }
                case "Error":
                    {
                        alert("Hubo una interrupción en la conexión con la base de datos. Por favor intente de nuevo más tarde.");
                        break;
                    }
                default:
                    {
                        rellenadatosexistentes(data);
                        break;
                    }
            }
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Persona//

function cargarPersona(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infodepersonacarga', 'Cargando el listado de Personas');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'Persona',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infodepersonacarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Identificación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Nombre</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Nombre Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Ubicación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Teléfono</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fax</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Correo Electrónico</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].IdentificacionNumero1.Numero1 + '</td><td class="text-left">' + data[indice].Nombre1 + '</td><td class="text-left">' + data[indice].NombreComercial1 + '</td><td class="text-left">' + data[indice].UbicacionID1.ID1 + data[indice].UbicacionID1.Provincia1 + data[indice].UbicacionID1.Canton1 + data[indice].UbicacionID1.Distrito1 + data[indice].UbicacionID1.Barrio1 + data[indice].UbicacionID1.OtrasSenas1 + '</td><td class="text-left">' + data[indice].TelefonoNumero1.CodigoPais1 + '-' + data[indice].TelefonoNumero1.NumTelefono1 + '</td><td class="text-left">' + data[indice].FaxNumero1.CodigoPais1 + '-' + data[indice].FaxNumero1.NumTelefono1 + '</td><td class="text-left">' + data[indice].CorreoElectronico1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].IdentificacionNumero1.Numero1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Identificación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Nombre</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Nombre Comercial</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Ubicación</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Teléfono</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Fax</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Correo Electrónico</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Persona a un Select//

function cargarPersonaaSelect(cargarselect) {

    $.ajax({
        url: urlconectar + 'Persona',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            if (data.length > 0) {
                for (var indice in data) {

                    cargarselect.innerHTML += '<option id=' + data[indice].IdentificacionNumero1.Numero1 + ' value=' + data[indice].IdentificacionNumero1.Numero1 + '>' + data[indice].IdentificacionNumero1.Numero1 + ' ' + data[indice].Nombre1 + '</option>';

                }


            }
            else {
            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Persona Emisor Para Seleccionar//

function cargarPersonaEmisorParaSeleccionar(espaciomostraravance, iddelatabla) {

    espaciomostraravance.innerHTML += creadorloader('infodeemisorescarga', 'Cargando el listado de Emisores');
    document.getElementById(iddelatabla).innerHTML = "";
    $.ajax({
        url: urlconectar + 'Persona',
        type: 'GET',
        dataType: 'json',
        data: Persona,
        success: function (data, textStatus, xhr) {

            $("#infodeemisorescarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById(iddelatabla).innerHTML += '<thead><tr id="filalistadocabeza' + iddelatabla + '"></tr></thead>';

                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Identificación</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Nombre</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Nombre Comercial</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Ubicación</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Teléfono</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Fax</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Correo Electrónico</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Seleccionar</th>';

                document.getElementById(iddelatabla).innerHTML += '<tbody id="listadocuerpo' + iddelatabla + '"></tbody>';

                document.getElementById(iddelatabla).innerHTML += '';


                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo" + iddelatabla).innerHTML += '<tr><td class="text-left">' + data[indice].IdentificacionNumero1.Numero1 + '</td><td class="text-left">' + data[indice].Nombre1 + '</td><td class="text-left">' + data[indice].NombreComercial1 + '</td><td class="text-left">' + data[indice].UbicacionID1.ID1 + data[indice].UbicacionID1.Provincia1 + data[indice].UbicacionID1.Canton1 + data[indice].UbicacionID1.Distrito1 + data[indice].UbicacionID1.Barrio1 + data[indice].UbicacionID1.OtrasSenas1 + '</td><td class="text-left">' + data[indice].TelefonoNumero1.CodigoPais1 + '-' + data[indice].TelefonoNumero1.NumTelefono1 + '</td><td class="text-left">' + data[indice].FaxNumero1.CodigoPais1 + '-' + data[indice].FaxNumero1.NumTelefono1 + '</td><td class="text-left">' + data[indice].CorreoElectronico1 + '</td><td class="text-left"><input type="button" value="Seleccionar" id="btnselecciona" onclick="selectEmisorPersona(' + objetoserializadocomillas + ')"/></td></tr>';

                }
                $('#' + iddelatabla).DataTable();


            }
            else {

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Persona Receptor Para Seleccionar//

function cargarPersonaReceptorParaSeleccionar(espaciomostraravance, iddelatabla) {

    espaciomostraravance.innerHTML += creadorloader('infodereceptorescarga', 'Cargando el listado de Receptores');
    document.getElementById(iddelatabla).innerHTML = "";
    $.ajax({
        url: urlconectar + 'Persona',
        type: 'GET',
        dataType: 'json',
        data: Persona,
        success: function (data, textStatus, xhr) {

            $("#infodereceptorescarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById(iddelatabla).innerHTML += '<thead><tr id="filalistadocabeza' + iddelatabla + '"></tr></thead>';

                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Identificación</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Nombre</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Nombre Comercial</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Ubicación</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Teléfono</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Fax</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Correo Electrónico</th>';
                document.getElementById("filalistadocabeza" + iddelatabla).innerHTML += '<th>Seleccionar</th>';

                document.getElementById(iddelatabla).innerHTML += '<tbody id="listadocuerpo' + iddelatabla + '"></tbody>';

                document.getElementById(iddelatabla).innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo" + iddelatabla).innerHTML += '<tr><td class="text-left">' + data[indice].IdentificacionNumero1.Numero1 + '</td><td class="text-left">' + data[indice].Nombre1 + '</td><td class="text-left">' + data[indice].NombreComercial1 + '</td><td class="text-left">' + data[indice].UbicacionID1.ID1 + data[indice].UbicacionID1.Provincia1 + data[indice].UbicacionID1.Canton1 + data[indice].UbicacionID1.Distrito1 + data[indice].UbicacionID1.Barrio1 + data[indice].UbicacionID1.OtrasSenas1 + '</td><td class="text-left">' + data[indice].TelefonoNumero1.CodigoPais1 + '-' + data[indice].TelefonoNumero1.NumTelefono1 + '</td><td class="text-left">' + data[indice].FaxNumero1.CodigoPais1 + '-' + data[indice].FaxNumero1.NumTelefono1 + '</td><td class="text-left">' + data[indice].CorreoElectronico1 + '</td><td class="text-left"><input type="button" value="Seleccionar" id="btnselecciona" onclick="selectReceptorPersona(' + objetoserializadocomillas + ')"/></td></tr>';

                }
                $('#' + iddelatabla).DataTable();


            }
            else {

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}



                                                          //Ajax de Resumen Factura//

var ResumenFactura = new Object();
ResumenFactura.TotalServGravados = "";
ResumenFactura.TotalServExentos = "";
ResumenFactura.TotalServExonerado = "";
ResumenFactura.TotalMercanciasGravadas = "";
ResumenFactura.TotalMercanciasExentas = "";
ResumenFactura.TotalMercanciasExoneradas = "";
ResumenFactura.TotalGravado = "";
ResumenFactura.TotalExento = "";
ResumenFactura.TotalExonerado = "";
ResumenFactura.TotalVenta = "";
ResumenFactura.TotalDescuentos = "";
ResumenFactura.TotalVentaNeta = "";
ResumenFactura.TotalImpuesto = "";
ResumenFactura.TotalIVADevuelto = "";
ResumenFactura.TotalOtrosCargos = "";
ResumenFactura.TotalComprobante = "";
ResumenFactura.Clave = "";
ResumenFactura.CodigoTipoMoneda = "";


//Guardar Resumen Factura//

function guardarResumenFactura(ResumenFactura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infoderesumenfacturaguarda' + ResumenFactura.Clave, 'Guardando Resumen Factura ' + ResumenFactura.Clave);

    $.ajax({
        url: urlconectar + 'ResumenFactura',
        type: 'PUT',
        dataType: 'json',
        data: ResumenFactura,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infoderesumenfacturaguarda" + data[1]).remove();
            limpiarcampos();
            cargarResumenFactura(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Eliminar Resumen Factura//

function eliminarResumenFactura(ResumenFactura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infoderesumenfacturaelimina' + ResumenFactura.Clave, 'Eliminando Resumen Factura ' + ResumenFactura.Clave);

    $.ajax({
        url: urlconectar + 'ResumenFactura',
        type: 'DELETE',
        dataType: 'json',
        data: ResumenFactura,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infoderesumenfacturaelimina" + data[1]).remove();
            limpiarcampos();
            cargarResumenFactura(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Modificar Resumen Factura//

function modificarResumenFactura(ResumenFactura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infoderesumenfacturamodifica' + ResumenFactura.Clave, 'Modificando Resumen Factura ' + ResumenFactura.Clave);

    $.ajax({
        url: urlconectar + 'ResumenFactura',
        type: 'POST',
        dataType: 'json',
        data: ResumenFactura,
        success: function (data, textStatus, xhr) {
            alert(data[0]);

            espaciomostraravance.innerHTML += "";
            $("#infoderesumenfacturamodifica" + data[1]).remove();
            limpiarcampos();
            cargarResumenFactura(espaciomostraravance);
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Verificar Resumen Factura//

function verificarResumenFactura(ResumenFactura, espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infoderesumenfacturaverifica' + ResumenFactura.Clave, 'Verificando Resumen Factura ' + ResumenFactura.Clave);

    $.ajax({
        url: urlconectar + 'ResumenFactura?id=' + ResumenFactura.Clave,
        type: 'GET',
        dataType: 'json',
        data: ResumenFactura,
        success: function (data, textStatus, xhr) {
            espaciomostraravance.innerHTML += "";
            $("#infoderesumenfacturaverifica" + ResumenFactura.Clave).remove();

            switch (data.Confirmacion1) {

                case "No Existe":
                    {
                        alert("No existen datos con esos parámetros. Ya puede crearlos.");
                        limpiadatosparanuevo();
                        break;
                    }
                case "Error":
                    {
                        alert("Hubo una interrupción en la conexión con la base de datos. Por favor intente de nuevo más tarde.");
                        break;
                    }
                default:
                    {
                        rellenadatosexistentes(data);
                        break;
                    }
            }
        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}

//Cargar Resumen Factura//

function cargarResumenFactura(espaciomostraravance) {

    espaciomostraravance.innerHTML += creadorloader('infoderesumenfacturacarga', 'Cargando el listado de Resumen Factura');
    document.getElementById("listado").innerHTML = "";
    $.ajax({
        url: urlconectar + 'ResumenFactura',
        type: 'GET',
        dataType: 'json',
        data: null,
        success: function (data, textStatus, xhr) {

            $("#infoderesumenfacturacarga").remove();
            espaciomostraravance.innerHTML += "";
            limpiarcampos();

            if (data.length > 0) {
                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Servicios Gravados</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Servicios Exentos</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Servicios Exonerados</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Mercancías Gravadas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Mercancías Exentas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Mercancías Exoneradas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total Gravado</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total Exento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total Exonerado</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Venta</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Descuentos</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Venta Neta</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Impuesto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de IVA Devuelto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Otros Cargos</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Comprobante</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código de Tipo de Moneda</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

                document.getElementById("listado").innerHTML += '';
                for (var indice in data) {
                    var objetoserializado = JSON.stringify(data[indice]);
                    var objetoserializadocomillas = "";
                    for (var caracter in objetoserializado) {

                        objetoserializadocomillas += objetoserializado[caracter].replace('"', "'");

                    }

                    document.getElementById("listadocuerpo").innerHTML += '<tr><td class="text-left">' + data[indice].Clave1.Clave1 + '</td><td class="text-left">' + data[indice].TotalServGravados1 + '</td><td class="text-left">' + data[indice].TotalServExentos1 + '</td><td class="text-left">' + data[indice].TotalServExonerado1 + '</td><td class="text-left">' + data[indice].TotalMercanciasGravadas1 + '</td><td class="text-left">' + data[indice].TotalMercanciasExentas1 + '</td><td class="text-left">' + data[indice].TotalMercanciasExoneradas1 + '</td><td class="text-left">' + data[indice].TotalGravado1 + '</td><td class="text-left">' + data[indice].TotalExento1 + '</td><td class="text-left">' + data[indice].TotalExonerado1 + '</td><td class="text-left">' + data[indice].TotalVenta1 + '</td><td class="text-left">' + data[indice].TotalDescuentos1 + '</td><td class="text-left">' + data[indice].TotalVentaNeta1 + '</td><td class="text-left">' + data[indice].TotalImpuesto1 + '</td><td class="text-left">' + data[indice].TotalIVADevuelto1 + '</td><td class="text-left">' + data[indice].TotalOtrosCargos1 + '</td><td class="text-left">' + data[indice].TotalComprobante1 + '</td><td class="text-left">' + data[indice].CodigoTipoMoneda1.CodigoMoneda1 + '</td><td class="text-left"><input type="button" value="Modificar" id="btnmodifica" onclick="cargardatosenelformulario(' + objetoserializadocomillas + ')"/></td><td class="text-left"><input type="button" value="Eliminar" id="btnelimina" onclick="verificareliminar(\'' + data[indice].Clave1.Clave1 + '\')"/></td></tr>';

                }


            }
            else {

                document.getElementById("listado").innerHTML += '<thead><tr id="filalistadocabeza"></tr></thead>';

                document.getElementById("filalistadocabeza").innerHTML += '<th>Clave</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Servicios Gravados</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Servicios Exentos</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Servicios Exonerados</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Mercancías Gravadas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Mercancías Exentas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Mercancías Exoneradas</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total Gravado</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total Exento</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total Exonerado</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Venta</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Descuentos</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Venta Neta</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Impuesto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de IVA Devuelto</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Otros Cargos</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Total de Comprobante</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Código de Tipo de Moneda</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Modificar</th>';
                document.getElementById("filalistadocabeza").innerHTML += '<th>Eliminar</th>';


                document.getElementById("listado").innerHTML += '<tbody class="table-hover" id="listadocuerpo"></tbody>';

            }

        },

        error: function (xhr, textStatus, errorThrown) {
            alert(xhr);
            limpiarcampos();
            espaciomostraravance.innerHTML += "";
        }
    });

}


//Cálculos Línea Detalle//

var LineaDetalle_Impuesto_Exoneracion = new Object();

LineaDetalle_Impuesto_Exoneracion.LineaDetalleConsecutivo = "";
LineaDetalle_Impuesto_Exoneracion.ImpuestoCodigo = "";
LineaDetalle_Impuesto_Exoneracion.ExoneracionTipo = "";
LineaDetalle_Impuesto_Exoneracion.ExoneracionNumeroDocumento = "";


var impuestoscargados = [];
var exoneracionescargadas = [];

function selectImpuestoLineaDetalle(id) {
    LineaDetalle_Impuesto_Exoneracion.ImpuestoCodigo = id;
    LineaDetalle_Impuesto_Exoneracion.LineaDetalleConsecutivo = LineaDetalle.Consecutivo;
    LineaDetalle_Impuesto_Exoneracion.ExoneracionTipo = "";
    LineaDetalle_Impuesto_Exoneracion.ExoneracionNumeroDocumento = "";
}

function calculoMontoTotal() {
    if (LineaDetalle.Cantidad != "" && LineaDetalle.PrecioUnitario != "") {
        LineaDetalle.MontoTotal = LineaDetalle.Cantidad * LineaDetalle.PrecioUnitario;
    }
}

function calculoMontoTotalConDescuento() {
    if (LineaDetalle.MontoDescuento == "") {
        LineaDetalle.MontoDescuento = "0";
    }
    if (LineaDetalle.MontoTotal == "") {
        LineaDetalle.MontoTotal = "0";
    }
    LineaDetalle.Subtotal = LineaDetalle.MontoTotal - LineaDetalle.MontoDescuento;
}

function calculoImpuestosActuales() {
    var calculomontodeimpuesto = 0;
    var tarifacalculando = 0;
    for (var indice in LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion) {
        for (var indiceimpuesto in impuestoscargados) {
            if (LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ImpuestoCodigo == impuestoscargados[indiceimpuesto].Codigo1) {

                tarifacalculando = LineaDetalle.Subtotal * (impuestoscargados[indiceimpuesto].Tarifa1 / 100);
                if (LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionNumeroDocumento != "") {
                    for (var indiceexoneracion in exoneracionescargadas) {
                        if (exoneracionescargadas[indiceexoneracion].TipoDocumento1 == LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionTipo && exoneracionescargadas[indiceexoneracion].NumeroDocumento1 == LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionNumeroDocumento) {
                            tarifacalculando = tarifacalculando - (tarifacalculando * (exoneracionescargadas[indiceexoneracion].PorcentajeExoneracion1 / 100));
                        }
                    }
                }
                calculomontodeimpuesto = calculomontodeimpuesto + tarifacalculando;
            }
        }
    }
    LineaDetalle.ImpuestoNeto = calculomontodeimpuesto;
    LineaDetalle.MontoTotalLinea = LineaDetalle.Subtotal + calculomontodeimpuesto;
}

function automatizacionCalculos(controlmontototal, controlsubtotal, controlimpuestoneto, controlmontototallinea) {
    calculoMontoTotal();
    calculoMontoTotalConDescuento();
    calculoImpuestosActuales();
    controlmontototal.value = LineaDetalle.MontoTotal;
    controlsubtotal.value = LineaDetalle.Subtotal;
    controlimpuestoneto.value = LineaDetalle.ImpuestoNeto;
    controlmontototallinea.value = LineaDetalle.MontoTotalLinea;
}

function cargarImpuestosExoneracionesSeleccionados(tablaparamostrar) {
    tablaparamostrar.innerHTML = "";
    tablaparamostrar.innerHTML += '<thead><tr id="filalistadocabezaimpuestoexoneracionselect"></tr></thead>';

    document.getElementById("filalistadocabezaimpuestoexoneracionselect").innerHTML += '<th scope="col">Código de Impuesto</th>';
    document.getElementById("filalistadocabezaimpuestoexoneracionselect").innerHTML += '<th scope="col">Exoneración</th>';
    document.getElementById("filalistadocabezaimpuestoexoneracionselect").innerHTML += '<th scope="col">Tarifa</th>';
    document.getElementById("filalistadocabezaimpuestoexoneracionselect").innerHTML += '<th scope="col">Eliminar</th>';

    tablaparamostrar.innerHTML += '<tbody class="table-hover" id="listadocuerpoimpuestoexoneracionselect"></tbody>';
    for (var indice in LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion) {
        var tarifa = 0;
        var exotarifa = 0;
        for (var indiceimpuesto in impuestoscargados) {
            if (LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ImpuestoCodigo == impuestoscargados[indiceimpuesto].Codigo1) {
                tarifa = impuestoscargados[indiceimpuesto].Tarifa1;
                break;
            }
        }
        if (LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionNumeroDocumento != "") {
            for (var indiceexoneracion in exoneracionescargadas) {
                if (exoneracionescargadas[indiceexoneracion].TipoDocumento1 == LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionTipo && exoneracionescargadas[indiceexoneracion].NumeroDocumento1 == LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionNumeroDocumento) {
                    exotarifa = exoneracionescargadas[indiceexoneracion].PorcentajeExoneracion1;
                    break;
                }
            }
            document.getElementById("listadocuerpoimpuestoexoneracionselect").innerHTML += '<tr><td class="text-left">' + LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ImpuestoCodigo + '</td><td class="text-left">' + LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionNumeroDocumento + ' ' + LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ExoneracionTipo + '</td><td class="text-left"> Tarifa del Impuesto: ' + tarifa + '%, Tarifa Exonerada: ' + exotarifa + '%</td><td class="text-left"><input type="button" value="Eliminar" id="btneliminar" onclick="eliminarImpuestoSeleccionado(' + LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ImpuestoCodigo + ')"/></td></tr>';
        }
        else {
            document.getElementById("listadocuerpoimpuestoexoneracionselect").innerHTML += '<tr><td class="text-left">' + LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ImpuestoCodigo + '</td><td class="text-left">No Aplica</td><td class="text=left"> Tarifa del Impuesto: ' + tarifa + '%</td><td class="text=left><input type="button" value="Eliminar" id="btneliminar" onclick="eliminarImpuestoSeleccionado(' + LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ImpuestoCodigo + ')"/></td></tr>';
        }
    }
    automatizacionCalculos(document.getElementById("montototal"), document.getElementById("subtotal"), document.getElementById("impuestoneto"), document.getElementById("montototallinea"));
}

function eliminarImpuestoSeleccionado(impcodigo) {
    for (var indice in LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion) {
        if (LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion[indice].ImpuestoCodigo == impcodigo) {
            LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion.splice(indice, 1);
            break;
        }
    }
    cargarImpuestosExoneracionesSeleccionados(document.getElementById('impuestosagregados'));
}

function agregarImpuestoExoneracion() {
    var nuevoimpuestoexoneracion = new Object();

    nuevoimpuestoexoneracion.LineaDetalleConsecutivo = LineaDetalle_Impuesto_Exoneracion.LineaDetalleConsecutivo;
    nuevoimpuestoexoneracion.ImpuestoCodigo = LineaDetalle_Impuesto_Exoneracion.ImpuestoCodigo;
    nuevoimpuestoexoneracion.ExoneracionTipo = LineaDetalle_Impuesto_Exoneracion.ExoneracionTipo;
    nuevoimpuestoexoneracion.ExoneracionNumeroDocumento = LineaDetalle_Impuesto_Exoneracion.ExoneracionNumeroDocumento;

    LineaDetalle.ListaActualDeLineaDetalle_Impuesto_Exoneracion.push(nuevoimpuestoexoneracion);
    cargarImpuestosExoneracionesSeleccionados(document.getElementById('impuestosagregados'));
}

function selectExoneracionLineaDetalle(tipo, numero) {
    LineaDetalle_Impuesto_Exoneracion.ExoneracionTipo = tipo;
    LineaDetalle_Impuesto_Exoneracion.ExoneracionNumeroDocumento = numero;
    agregarImpuestoExoneracion();
}



//Funciones Para Mostrar Facturas//


function selectLineaDetalleFactura(objeto) {
    objeto.NumeroLinea1 = parseInt(Factura.LineaDetalleFactura.length) + 1;
    var person = prompt("Desea cambiar la cantidad de unidades de la línea, que actualmente es " + objeto.Cantidad1, "");

    if (person == null || person == "") {

    }
    else {
        objeto.ImpuestoNeto1 = (objeto.ImpuestoNeto1 / objeto.Cantidad1) * person;
        objeto.Cantidad1 = person;
        objeto.MontoTotal1 = objeto.Cantidad1 * objeto.PrecioUnitario1;
        objeto.Subtotal1 = objeto.MontoTotal1 - objeto.MontoDescuento1.MontoDescuento1;

        objeto.MontoTotalLinea1 = objeto.Subtotal1 - objeto.ImpuestoNeto1;

        Factura.LineaDetalleFactura.push(objeto);
        cargarLineaDetalleParaMostrar(document.getElementById("lineasdetalleagregados"));
    }
    
}

function selectEmisorPersona(objeto) {
    document.getElementById("espaciomostraravance").innerHTML += creadorloader('infodeemisorpersonacarga', 'Seleccionando al Emisor ' + objeto.Nombre1);

    Factura.Emisor = objeto.IdentificacionNumero1.Numero1;
    document.getElementById("emisor").value = objeto.IdentificacionNumero1.Numero1;

    $("#infodeemisorpersonacarga").remove();
    document.getElementById("espaciomostraravance").innerHTML += "";
}

function selectReceptorPersona(objeto) {
    document.getElementById("espaciomostraravance").innerHTML += creadorloader('infodereceptorpersonacarga', 'Seleccionando al Receptor ' + objeto.Nombre1);

    Factura.Receptor = objeto.IdentificacionNumero1.Numero1;
    document.getElementById("receptor").value = objeto.IdentificacionNumero1.Numero1;

    $("#infodereceptorpersonacarga").remove();
    document.getElementById("espaciomostraravance").innerHTML += "";
}

function eliminarLineaDetalleFacturaSeleccionada(impcodigo) {
    for (var indice in Factura.LineaDetalleFactura) {
        if (Factura.LineaDetalleFactura[indice].Consecutivo1 == impcodigo) {
            Factura.LineaDetalleFactura.splice(indice, 1);
            break;
        }
    }
    cargarLineaDetalleParaMostrar(document.getElementById("lineasdetalleagregados"));
}

function cargarLineaDetalleParaMostrar(tablaparamostrar) {
    tablaparamostrar.innerHTML = "";
    tablaparamostrar.innerHTML += '<thead><tr id="filalistadocabezalineasdetalleselect"></tr></thead>';
    
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Consecutivo</th>';
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Cantidad</th>';
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Precio Unitario</th>';
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Impuesto Neto</th>';
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Monto Total de Línea</th>';
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Tipo de Código Comercial</th>';
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Código Comercial</th>';
    document.getElementById("filalistadocabezalineasdetalleselect").innerHTML += '<th scope="col">Eliminar</th>';

    tablaparamostrar.innerHTML += '<tbody class="table-hover" id="listadocuerpolineasdetalleselect"></tbody>';

    for (var indice in Factura.LineaDetalleFactura) {
        if (Factura.LineaDetalleFactura[indice].Consecutivo1 != "") {

            document.getElementById("listadocuerpolineasdetalleselect").innerHTML += '<tr><td class="text-left">' + Factura.LineaDetalleFactura[indice].Consecutivo1 + '</td><td class="text-left">' + Factura.LineaDetalleFactura[indice].Cantidad1 + '</td><td class="text-left">' + Factura.LineaDetalleFactura[indice].PrecioUnitario1 + '</td><td class="text-left">' + Factura.LineaDetalleFactura[indice].ImpuestoNeto1 + '</td><td class="text-left">' + Factura.LineaDetalleFactura[indice].MontoTotalLinea1 + '</td><td class="text-left">' + Factura.LineaDetalleFactura[indice].CodigoComercialTipo1.Tipo1 + '</td><td class="text-left">' + Factura.LineaDetalleFactura[indice].CodigoComercialCodigo1.Codigo1 + '</td><td class="text-left"><input type="button" value="Eliminar" id="btneliminar" onclick="eliminarLineaDetalleFacturaSeleccionada(' + Factura.LineaDetalleFactura[indice].Consecutivo1 + ')"/></td></tr>';
        }
    } 
}