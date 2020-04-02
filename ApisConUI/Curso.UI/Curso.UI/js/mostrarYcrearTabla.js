$(document).ready(function () {

	//************ DIBUJAR TABLA	******************************
	$.fn.dibujarTabla = function (data) {
		let html = "";
		$.each(data.headers, function (index, value) {
			html += "<th>" + value + "</th>";
		});
		html = "<tr>" + html + "</tr>";
		let row = "";
		$.each(data.rows, function (index, value) {
			row = "";
			$.each(value, function (index, value) {
				row += "<td>" + value + "</td>";
			});
			html += "<tr>" + row + "</tr>"
		});
		html = "<table class='table'>" + html + "</table>"
		this.html(html);
	}


	//************ MOSTRAR TABLA	******************************
	$("#btnMostrarTabla").click(function () {

		$.ajax({
			url: "https://localhost:5003/api/Tables/Grilla1",
			method: "GET",
			crossDomain: true,
			headers: {
				"Accept": "application/json",
			},
			//data: JSON.stringify(data),
			dataType: 'json',
			contentType: "application/json; charset=utf-8",
			success: function (data) {
				if (typeof data !== "object") {
					data = data.d || data;
					data = JSON.parse(data);
				}
				$("#Inicial").hide();
				$("#tabla").dibujarTabla(data);
				$("#tabla").show();
			},
			error: function (xhr) {
				alert((xhr.responseJSON).message)
				//console.log(xhr);
			}
		});
		$("#btnVolverDeTabla").show();
	})

});