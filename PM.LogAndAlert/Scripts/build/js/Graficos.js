function init_flot_chart(data1, data2) {

    if (typeof ($.plot) === 'undefined') { return; }
    if (typeof (data1) === 'undefined' || typeof (data2) === 'undefined') {
        // Se não vier data alguma, estipula os ultimos 30 dias como default
        var dateI = new Date(); dateI.addDays(-29);
        var dateF = new Date(); dateF.addDays(0);
        data2 = dateI.getDate() + '/' + (dateI.getMonth() + 1) + '/' + dateI.getFullYear();
        data1 = dateF.getDate() + '/' + (dateF.getMonth() + 1) + '/' + dateF.getFullYear();
    }
    $.ajax({
        cache: false,
        type: 'GET',
        url: '/DashBoard/gr_NotasAbertasPendentes?data1=' + data1 + '&data2=' + data2,
        success: function (dataJson) {
            // Transforma a instrução Json em Objetos JavaScript
            var data = JSON.parse(dataJson);
            if (data != null) { // we are going to render partial view inside a Div tag // this is the part i wanted to share with you all..
                $('#dvPerformancePeriodo_' + data[0].label.replace(" ", "")).css('width', (data[0].totalizador / (9867 / 100)) + '%').attr('aria-valuenow', (data[0].totalizador / (9867 / 100)));
                $('#dvPerformancePeriodo_' + data[1].label.replace(" ", "")).css('width', (data[1].totalizador / (9867 / 100)) + '%').attr('aria-valuenow', (data[1].totalizador / (9867 / 100)));
                $('#dvPerformancePeriodo_' + data[2].label.replace(" ", "")).css('width', (data[2].totalizador / (9867 / 100)) + '%').attr('aria-valuenow', (data[2].totalizador / (9867 / 100)));
                $('#dvPerformancePeriodo_' + data[3].label.replace(" ", "")).css('width', (data[3].totalizador / (9867 / 100)) + '%').attr('aria-valuenow', (data[3].totalizador / (9867 / 100)));
                /////document.getElementById("spPerformancePeriodo_Total").textContent = "9867";

                //$('#dvPerformancePeriodo_' + data[2].label.replace(" ", "")).css('width', ((1000 / 10) + 0) + '%').attr('aria-valuenow', ((1000 / 10) + 0));

                var dataset = [
                    { label: data[0].label, color: data[0].color, data: data[0].data },
                    { label: data[1].label, color: data[1].color, data: data[1].data },
                    { label: data[2].label, color: data[2].color, data: data[2].data },
                    { label: data[3].label, color: data[3].color, data: data[3].data }
                ];
                var chart_plot_01_settings = {
                    series: {
                        lines: { show: false, fill: true },
                        splines: { show: true, tension: 0.4, lineWidth: 3, fill: 0.4 },
                        points: { radius: 0, show: true },
                        shadowSize: 3
                    },
                    grid: {
                        verticalLines: true,
                        hoverable: true,
                        clickable: true,
                        tickColor: "#d5d5d5",
                        borderWidth: 2,
                        color: '#e5e5e5'
                    },
                    xaxis: {
                        tickColor: "rgba(51, 51, 51, 0.06)",
                        mode: "time",
                        tickSize: [1, "day"],
                        tickLength: 10,
                        axisLabel: "Date",
                        axisLabelUseCanvas: true,
                        axisLabelFontSizePixels: 12,
                        axisLabelFontFamily: 'Verdana, Arial',
                        axisLabelPadding: 10
                    },
                    yaxis: {
                        ticks: 8,
                        tickColor: "rgba(51, 51, 51, 0.06)"
                    },
                    legend: {
                        noColumns: 0,
                        backgroundColor: "#000",
                        labelBoxBorderColor: "#000000",
                        noColumns: 0,
                        backgroundOpacity: 0.5,
                        position: "ne" // "ne" or "nw" or "se" or "sw"                            
                    },
                    tooltip: true
                }
                if ($("#chart_plot_01").length) { $.plot($("#chart_plot_01"), dataset, chart_plot_01_settings); }
            }
            //$modal.html(data);
        }
    });
}

function init_morris_charts_semestre() {

    if (typeof (Morris) === 'undefined') { return; }
    console.log('init_morris_charts');

    if ($('#graph_bar_group').length) {

        Morris.Bar({
            element: 'graph_bar_group',
            data: [
                { "period": "2018-10-31", "Rodante": 2657, "Equipamento": 1967, "Manobra": 4354, "Oficina": 2353 },
                { "period": "2018-11-30", "Rodante": 3148, "Equipamento": 2627, "Manobra": 4354, "Oficina": 2353 },
                { "period": "2018-12-31", "Rodante": 3471, "Equipamento": 3740, "Manobra": 4354, "Oficina": 2353 },
                { "period": "2019-01-31", "Rodante": 2871, "Equipamento": 2216, "Manobra": 4354, "Oficina": 2353 },
                { "period": "2019-02-28", "Rodante": 2401, "Equipamento": 1656, "Manobra": 4354, "Oficina": 2353 },
                { "period": "2019-03-11", "Rodante": 2115, "Equipamento": 1022, "Manobra": 4354, "Oficina": 2353 }
            ],
            xkey: 'period',
            barColors: ['#3498DB', '#1ABB9C', '#E74C3C', '#9B59B6'],
            ykeys: ['Rodante', 'Equipamento', 'Manobra', 'Oficina'],
            labels: ['Rodante', 'Equip. Fixo', 'Manobra', 'Oficina'],
            hideHover: 'auto',
            xLabelAngle: 60,
            resize: true
        });
    }

};

function init_morris_charts_semanal() {

    if (typeof (Morris) === 'undefined') { return; }
    console.log('init_morris_charts');

    if ($('#graphx').length) {

        Morris.Bar({
            element: 'graphx',
            data: [
                { x: '11/02 á 18/02', y: 2, z: 3, a: 4, m: 2 },
                { x: '19/02 á 25/02', y: 3, z: 5, a: 6, m: 12 },
                { x: '26/02 á 04/03', y: 4, z: 3, a: 2, m: 7 },
                { x: '05/03 á 11/03', y: 2, z: 4, a: 5, m: 6 }
            ],
            xkey: 'x',
            ykeys: ['y', 'z', 'a', 'm'],
            barColors: ['#3498DB', '#1ABB9C', '#E74C3C', '#9B59B6'],
            hideHover: 'auto',
            labels: ['Rodante', 'Equipamento', 'Manobra', 'Oficina'],
            resize: true
        }).on('click', function (i, row) {
            console.log(i, row);
        });

    }
};

function init_chart_doughnut() {

    if (typeof (Chart) === 'undefined') { return; }
    if ($('.canvasDoughnut').length) {

        var chart_doughnut_settings = {
            type: 'doughnut',
            tooltipFillColor: "rgba(51, 51, 51, 0.55)",
            data: {
                labels: ["Depto 001", "Depto 002", "Depto 003", "Depto 004", "Depto 005"],
                datasets: [{
                    data: [200, 131, 442, 153],
                    backgroundColor: ["#3498DB", "#1ABB9C", "#E74C3C", "#9B59B6"],
                    hoverBackgroundColor: ["#F39C12", "#F39C12", "#F39C12", "#F39C12"]
                }]
            },
            options: {
                legend: true,
                responsive: false
            }
        }

        $('.canvasDoughnut').each(function () {

            var chart_element = $(this);
            var chart_doughnut = new Chart(chart_element, chart_doughnut_settings);
        });

    }

}

function init_gauge() {

    if (typeof (Gauge) === 'undefined') { return; }

    console.log('init_gauge [' + $('.gauge-chart').length + ']');

    console.log('init_gauge');


    var chart_gauge_settings = {
        lines: 12,
        angle: 0,
        lineWidth: 0.4,
        pointer: {
            length: 0.75,
            strokeWidth: 0.042,
            color: '#1D212A'
        },
        limitMax: 'false',
        colorStart: '#1ABC9C',
        colorStop: '#1ABC9C',
        strokeColor: '#F0F3F3',
        generateGradient: true
    };


    if ($('#chart_gauge_01').length) {

        var chart_gauge_01_elem = document.getElementById('chart_gauge_01');
        var chart_gauge_01 = new Gauge(chart_gauge_01_elem).setOptions(chart_gauge_settings);

    }


    if ($('#gauge-text').length) {

        chart_gauge_01.maxValue = 6000;
        chart_gauge_01.animationSpeed = 32;
        chart_gauge_01.set(3200);
        chart_gauge_01.setTextField(document.getElementById("gauge-text"));

    }

    if ($('#chart_gauge_02').length) {

        var chart_gauge_02_elem = document.getElementById('chart_gauge_02');
        var chart_gauge_02 = new Gauge(chart_gauge_02_elem).setOptions(chart_gauge_settings);

    }


    if ($('#gauge-text2').length) {

        chart_gauge_02.maxValue = 9000;
        chart_gauge_02.animationSpeed = 32;
        chart_gauge_02.set(2400);
        chart_gauge_02.setTextField(document.getElementById("gauge-text2"));

    }


}   
function gd(year, month, day) {
    return new Date(year, month - 1, day).getTime();
}


$(document).ready(function () {

    init_flot_chart();
    init_morris_charts_semestre();
    init_morris_charts_semanal();
});