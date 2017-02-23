var myLines = [{
  "type": "LineString",
  "coordinates": [[1000, 400], [1050, 450], [1100, 550]]
}, {
  "type": "LineString",
  "coordinates": [[1050, 400], [1100, 450], [1150, 550]]
  }];

var myPolygons = [{
  "type": "Polygon",
  "coordinates": [[1828, 3474], [1810, 3431], [1910, 3393], [1930, 3432], [1828, 3474]]
}];

var bina_y = {
  "type": "Feature",
  "properties": {
    "popupContent": "Bu Y binasıdır.",
    "style": {
      weight: 2,
      color: "#999",
      opacity: 1,
      fillColor: "#B0DE5C",
      fillOpacity: 0.8
    }
  },
  "geometry": {
    "type": "Polygon",
    "coordinates": [
      //[[2399, 1549], [2263, 1498], [2281, 1456], [2417, 1508], [2399, 1549]]
      [[1549, 2399], [1498, 2263], [1456, 2281], [1508, 2417], [1549,2399]]
    ]
  }
};