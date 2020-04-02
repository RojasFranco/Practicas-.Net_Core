$(document).ready(function () {

	$("#CrearPersona").hide();	
	$("#btnVolverDeTabla").hide();
	$("#EliminaPersona").hide();
	$("#DniActualizar").hide();

	$("#btnAltaPersona").click(function () {
		$("#Inicial").hide();
		$("#CrearPersona").show();
	});

	$("#btnEliminarPersona").click(function () {
		$("#Inicial").hide();
		$("#EliminaPersona").show();
	});

	$("#btnActualizarPersona").click(function () {
		$("#Inicial").hide();
		$("#DniActualizar").show();
    })



	//******************************** BOTONES PARA VOLVER	****************************************
	$("#btnVolver").click(function () {

		$("#CrearPersona").hide();
		$("#Inicial").show();
	});

	$("#btnVolverDeTabla").click(function () {
		$("#tabla").hide();
		$("#btnVolverDeTabla").hide();
		$("#Inicial").show();
	});

	$("#btnVolverDeEliminar").click(function () {

		$("#EliminaPersona").hide();
		$("#Inicial").show();
	});

	$("#btnVolverDeActualizar").click(function () {
		$("#DniActualizar").hide();
		$("#Inicial").show();
	});

	//******************************** ALTA PERSONA	**************************************************
	$("#guardarPersona").click(function () {
		var nombreNew = $("#txtNombreIngresado").val();
		var apellidoNew = $("#txtApellidoIngresado").val();
		var dniNew = $("#txtDniIngresado").val();

		if (!isNaN(parseInt(dniNew)) && nombreNew.length > 2 && apellidoNew.length > 2) {

			var data = { nombreAlta: nombreNew, apellidoAlta: apellidoNew, dniAlta: parseInt(dniNew) }

			$.ajax({
				url: "https://localhost:5003/api/Tables/CrearPersona",
				data: JSON.stringify(data),
				crossDomain: true,
				dataType: 'json',
				headers: {
					"Accept": "application/json",
				},
				contentType: "application/json; charset=utf-8",
				method: "POST",
				success: function (respuesta) {
					debugger;
					alert(respuesta.message);
				},
				error: function (error) {
					debugger;
					let respuesta = error.responseJSON;

					alert(respuesta.message);
				}
			})
		}
		else {
			alert("Complete los campos")
		}
	});



//******************************** BAJA PERSONA	**************************************************
	$("#btnEliminar").click(function () {
		var dniEliminar = $("#txtDniEliminar").val();
		
		//if (!isNaN(parseInt(dniEliminar))) { ES VALIDO PERO ES MEJOR EXPRESION REGULAR
		if (dniEliminar.length > 0 && /^[0-9]*$/.test(dniEliminar)) {
			//var data = { dniAEliminar: parseInt(dniEliminar) }; ESTO NO FUNCIONA

			var userEliminar = parseInt(dniEliminar);

			$.ajax({
				url: "https://localhost:5003/api/Tables/BorrarPersona/" + userEliminar,
				method: "DELETE",
				//data: JSON.stringify(data), NO SE ENVIA NADA
				crossDomain: true,
				dataType: 'json',
				headers: {
					"Accept": "application/json",
				},
				contentType: "application/json; charset=utf-8",
				success: function (respuesta) {
					let responder = respuesta.message;
					alert(responder);
				},
				error: function (error) {
					debugger;
					let respuesta = error.responseJSON;
					alert(respuesta.message);
				}

			});
		}
		else {
			alert("Dni ingresado no es valido");
		}

	});



//******************************** ACTUALIZAR PERSONA  **************************************************
	$("#btnBuscar").click(function () {
		var dniActualizar = $("#txtDniActualizar").val();
		var nombreActualizar = $("#txtNombreActualizar").val();
		var apellidoActualizar = $("#txtApellidoActualizar").val();

		if (dniActualizar.length > 0 && /^[0-9]{8,9}$/.test(dniActualizar) && nombreActualizar.length > 2 && apellidoActualizar.length > 2) {
			var datoEnviar = { DNI: parseInt(dniActualizar), Name: nombreActualizar, SurName: apellidoActualizar };
			$.ajax({
				url:"https://localhost:5003/api/Tables/ActualizarPersona",
				method: "PUT",
				data: JSON.stringify(datoEnviar),
				crossDomain: true,
				dataType: 'json',
				headers: {
					"Accept": "application/json",
				},
				contentType: "application/json; charset=utf-8",
				success: function (respuesta) {
					debugger;
					alert(respuesta.message);
				},
				error: function (respuestaErr) {
					respuestaErr = respuestaErr.responseJSON;
					alert(respuestaErr.message);
				}
            })
		}
		else {
			alert("Complete los datos correctamente");
        }

	});




});
