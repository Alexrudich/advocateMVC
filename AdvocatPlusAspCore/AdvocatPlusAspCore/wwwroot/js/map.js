ymaps.ready(init);
var myMap, myPlacemark;

function init() {
    var myMap = new ymaps.Map("map", {
        center: [53.981416, 27.656603],
        zoom: 17
    });
    myPlacemark = new ymaps.Placemark([53.981416, 27.656603], {
        balloonContentHeader: "Юридическая консультация",
        balloonContentBody: "д. Боровляны-2, ул. Хвойная 2,Р-40",
        balloonContentFooter: "1-й км2, ком. 27.",
        hintContent: "Юридическая консультация"
    });
    myMap.geoObjects.add(myPlacemark);
}