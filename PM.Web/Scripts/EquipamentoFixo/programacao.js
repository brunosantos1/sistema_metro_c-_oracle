var GRID_REF_NAME = "tlef020101_navbar_state";

//bootstrap input spinner
$("input[type='number']").inputSpinner();
	
//gijgo datepicker
$('#inputOD').datepicker({
	locale: 'pt-br',
	format: 'dd/mm/yyyy',
	uiLibrary: 'bootstrap4'
});
	
//navigation bar
setupGrid();

function setupGrid() {
	var parentRows = $(".row-clickable");

	parentRows.click(function() {
		toggleRow($(this));
	});
	
    var navbar_state = JSON.parse(sessionStorage.getItem(GRID_REF_NAME)) || $();
	
	if (navbar_state) {
		parentRows.each(function() {
			var id = $(this).attr("id");
	
			var row_state;
			eval("row_state = navbar_state." + id + ";");
			
			toggleRow($(this), !!row_state);
		});
	} else {
        resetGrid();
	}
}

function toggleRow(parentRow, stat) {
	var id = parentRow.attr("id");
	var button = parentRow.find(".row-clickable-button").first().children().first();
	var children = $("." + id + "-child");
	var visible = stat != undefined ? stat : button.text() == "add";
    var navbar_state = JSON.parse(sessionStorage.getItem(GRID_REF_NAME)) || $();

	if (visible) {
		button.text("remove");
		children.show();
	} else {
		button.text("add");
		children.hide();
	}
	
	eval("navbar_state." + id + " = " + visible + ";");
    sessionStorage.setItem(GRID_REF_NAME, JSON.stringify(navbar_state));
}

function resetGrid() {
	var parentRows = $(".row-clickable");
	
	parentRows.each(function() {
		toggleRow($(this), false);
	});
}

$('#btn_microprogramacao').on('click', function () {
    window.location.href = '/EquipamentoFixo/VisualizarMicroprogramacao';
})

$('#btn_email').on('click', function () {
    window.location.href = '/EquipamentoFixo/EnvioEmail';
})

$('#btn_planejamento').on('click', function () {
    window.location.href = '/EquipamentoFixo/Planejamento';
})