var colors = Highcharts.getOptions().colors,
    categories = [
        'Earnings',
        'Deductions',
        'Net'
    ],
    data = [
        {
            y: 50,
            color: colors[2],
            drilldown: {
                name: 'Earnings',
                categories: [
                    'Basci Salary',
                    'Overtime - Weekend'
                ],
                data: [
                    37.5,
                    12.5
                ]
            }
        },
        {
            y: 12.5,
            color: colors[1],
            drilldown: {
                name: 'Deductions',
                categories: [
                    'N.S.S.F',
                    'N.H.I.F.',
                    'Pay As You Earn'
                ],
                data: [
                    0.5,
                    2,
                    10

                ]
            }
        },
        {
            y: 37.5,
            color: colors[0],
            drilldown: {
                name: 'Net',
                categories: [
                    'Net'
                ],
                data: [
                    37.5
                ]
            }
        }
    ],
    salaryData = [],
    percentageData = [],
    i,
    j,
    dataLen = data.length,
    drillDataLen,
    brightness;


// Build the data arrays
for (i = 0; i < dataLen; i += 1) {

    // add browser data
    salaryData.push({
        name: categories[i],
        y: data[i].y,
        color: data[i].color
    });

    // add percentage data
    drillDataLen = data[i].drilldown.data.length;
    for (j = 0; j < drillDataLen; j += 1) {
        brightness = 0.2 - (j / drillDataLen) / 5;
        percentageData.push({
            name: data[i].drilldown.categories[j],
            y: data[i].drilldown.data[j],
            color: Highcharts.color(data[i].color).brighten(brightness).get()
        });
    }
}

// Create the chart
Highcharts.chart('container', {
    chart: {
        type: 'pie'
    },
    title: {
        text: null
    },
    subtitle: {
        text: null
    },
    plotOptions: {
        pie: {
            shadow: false,
            center: ['50%', '50%'],
            startAngle: -90
        }
    },
    tooltip: {
        valueSuffix: '%'
    },
    series: [{
        name: 'Percentage',
        data: salaryData,
        size: '60%',
        dataLabels: {
            formatter: function () {
                return this.y > 5 ? this.point.name : null;
            },
            color: '#ffffff',
            distance: -30
        }
    }, {
        name: 'Percentage',
        data: percentageData,
        size: '80%',
        innerSize: '60%',
        dataLabels: {
            formatter: function () {
                // display only if larger than 1
                return this.y > 1 ? '<b>' + this.point.name + '</b> ' : null;
            }
        },
        id: 'percentages'
    }],
    responsive: {
        rules: [{
            condition: {
                maxWidth: 400
            },
            chartOptions: {
                series: [{
                }, {
                    id: 'percentages',
                    dataLabels: {
                        enabled: false
                    }
                }]
            }
        }]
    }
});