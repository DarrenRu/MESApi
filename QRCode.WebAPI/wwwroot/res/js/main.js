/* globals Chart:false, feather:false */

var data = {
    menu: [{
        name: 'item1',
        link: '#',
        icon: 'home',
        sub: null
    }, {
        name: 'item2',
        link: '#',
        icon: 'home',
        sub: null
    }, {
        name: 'item3',
        link: '#',
        sub: null,
        icon: 'file'
    }]
};

var getMenuItem = function (itemData) {
    var item = $("<li>", {
        class: 'nav-item'
    })
        .append(
            $("<a>", {
                href: '#' + itemData.link,
                html: "<span data-feather='" + itemData.icon + "'></span>" + itemData.name,
                class: 'nav-link'
            }));
    if (itemData.sub) {
        var subList = $("<ul>", {
            class: 'nav flex column mb-2'
        });
        $.each(itemData.sub, function () {
            subList.append(getMenuItem(this));
        });
        item.append(subList);
    }
    return item;
};

var $menu = $("#menu");
$.each(data.menu, function () {
    $menu.append(
        getMenuItem(this)
    );
});

feather.replace();

//(function () {
//    'use strict'
//      feather.replace()
//    // Graphs
//    var ctx = document.getElementById('myChart')
//    // eslint-disable-next-line no-unused-vars
//    var myChart = new Chart(ctx, {
//        type: 'line',
//        data: {
//            labels: [
//                'Sunday',
//                'Monday',
//                'Tuesday',
//                'Wednesday',
//                'Thursday',
//                'Friday',
//                'Saturday'
//            ],
//            datasets: [{
//                data: [
//                    15339,
//                    21345,
//                    18483,
//                    24003,
//                    23489,
//                    24092,
//                    12034
//                ],
//                lineTension: 0,
//                backgroundColor: 'transparent',
//                borderColor: '#007bff',
//                borderWidth: 4,
//                pointBackgroundColor: '#007bff'
//            }]
//        },
//        options: {
//            scales: {
//                yAxes: [{
//                    ticks: {
//                        beginAtZero: false
//                    }
//                }]
//            },
//            legend: {
//                display: false
//            }
//        }
//    })
//}())
