﻿/*
 Highcharts JS v8.0.4 (2020-03-10)

 (c) 2009-2019 Torstein Honsi

 License: www.highcharts.com/license
*/
(function (l) { "object" === typeof module && module.exports ? (l["default"] = l, module.exports = l) : "function" === typeof define && define.amd ? define("highcharts/modules/series-label", ["highcharts"], function (w) { l(w); l.Highcharts = w; return l }) : l("undefined" !== typeof Highcharts ? Highcharts : void 0) })(function (l) {
    function w(l, u, y, z) { l.hasOwnProperty(u) || (l[u] = z.apply(null, y)) } l = l ? l._modules : {}; w(l, "modules/series-label.src.js", [l["parts/Globals.js"], l["parts/Utilities.js"]], function (l, u) {
        function y(c, d, a, k, f, b) {
            c = (b - d) *
            (a - c) - (k - d) * (f - c); return 0 < c ? !0 : !(0 > c)
        } function z(c, d, a, k, f, b, g, n) { return y(c, d, f, b, g, n) !== y(a, k, f, b, g, n) && y(c, d, a, k, f, b) !== y(c, d, a, k, g, n) } function w(c, d, a, k, f, b, g, n) { return z(c, d, c + a, d, f, b, g, n) || z(c + a, d, c + a, d + k, f, b, g, n) || z(c, d + k, c + a, d + k, f, b, g, n) || z(c, d, c, d + k, f, b, g, n) } function F(c) {
            var d = this, a = B(d.renderer.globalAnimation).duration; d.labelSeries = []; d.labelSeriesMaxSum = 0; u.clearTimeout(d.seriesLabelTimer); d.series.forEach(function (k) {
                var f = k.options.label, b = k.labelBySeries, g = b && b.closest; f.enabled &&
                    k.visible && (k.graph || k.area) && !k.isSeriesBoosting && (d.labelSeries.push(k), f.minFontSize && f.maxFontSize && (k.sum = k.yData.reduce(function (a, b) { return (a || 0) + (b || 0) }, 0), d.labelSeriesMaxSum = Math.max(d.labelSeriesMaxSum, k.sum)), "load" === c.type && (a = Math.max(a, B(k.options.animation).duration)), g && ("undefined" !== typeof g[0].plotX ? b.animate({ x: g[0].plotX + g[1], y: g[0].plotY + g[2] }) : b.attr({ opacity: 0 })))
            }); d.seriesLabelTimer = I(function () { d.series && d.labelSeries && d.drawSeriesLabels() }, d.renderer.forExport || !a ? 0 :
                a)
        } var G = u.addEvent, B = u.animObject, H = u.extend, C = u.isNumber, A = u.pick, I = u.syncTimeout, D = l.Series, J = l.SVGRenderer, E = l.Chart; l.setOptions({ plotOptions: { series: { label: { enabled: !0, connectorAllowed: !1, connectorNeighbourDistance: 24, minFontSize: null, maxFontSize: null, onArea: null, style: { fontWeight: "bold" }, boxesToAvoid: [] } } } }); J.prototype.symbols.connector = function (c, d, a, k, f) {
            var b = f && f.anchorX; f = f && f.anchorY; var g = a / 2; if (C(b) && C(f)) {
                var n = ["M", b, f]; var h = d - f; 0 > h && (h = -k - h); h < a && (g = b < c + a / 2 ? h : a - h); f > d + k ? n.push("L",
                    c + g, d + k) : f < d ? n.push("L", c + g, d) : b < c ? n.push("L", c, d + k / 2) : b > c + a && n.push("L", c + a, d + k / 2)
            } return n || []
        }; D.prototype.getPointsOnGraph = function () {
            function c(b) { var c = Math.round(b.plotX / 8) + "," + Math.round(b.plotY / 8); m[c] || (m[c] = 1, a.push(b)) } if (this.xAxis || this.yAxis) {
                var d = this.points, a = [], k; var f = this.graph || this.area; var b = f.element; var g = this.chart.inverted, n = this.xAxis; var h = this.yAxis; var l = g ? h.pos : n.pos; g = g ? n.pos : h.pos; n = A(this.options.label.onArea, !!this.area); var x = h.getThreshold(this.options.threshold),
                    m = {}; if (this.getPointSpline && b.getPointAtLength && !n && d.length < this.chart.plotSizeX / 16) { if (f.toD) { var e = f.attr("d"); f.attr({ d: f.toD }) } var v = b.getTotalLength(); for (k = 0; k < v; k += 16)h = b.getPointAtLength(k), c({ chartX: l + h.x, chartY: g + h.y, plotX: h.x, plotY: h.y }); e && f.attr({ d: e }); h = d[d.length - 1]; h.chartX = l + h.plotX; h.chartY = g + h.plotY; c(h) } else for (v = d.length, k = 0; k < v; k += 1) {
                        h = d[k]; e = d[k - 1]; h.chartX = l + h.plotX; h.chartY = g + h.plotY; n && (h.chartCenterY = g + (h.plotY + A(h.yBottom, x)) / 2); if (0 < k && (f = Math.abs(h.chartX - e.chartX),
                            b = Math.abs(h.chartY - e.chartY), f = Math.max(f, b), 16 < f)) for (f = Math.ceil(f / 16), b = 1; b < f; b += 1)c({ chartX: e.chartX + b / f * (h.chartX - e.chartX), chartY: e.chartY + b / f * (h.chartY - e.chartY), chartCenterY: e.chartCenterY + b / f * (h.chartCenterY - e.chartCenterY), plotX: e.plotX + b / f * (h.plotX - e.plotX), plotY: e.plotY + b / f * (h.plotY - e.plotY) }); C(h.plotY) && c(h)
                    } return a
            }
        }; D.prototype.labelFontSize = function (c, d) { return c + this.sum / this.chart.labelSeriesMaxSum * (d - c) + "px" }; D.prototype.checkClearPoint = function (c, d, a, k) {
            var f = Number.MAX_VALUE,
            b = Number.MAX_VALUE, g, n = A(this.options.label.onArea, !!this.area), h = n || this.options.label.connectorAllowed, l = this.chart, x; for (x = 0; x < l.boxesToAvoid.length; x += 1) { var m = l.boxesToAvoid[x]; var e = c + a.width; var v = d; var t = d + a.height; if (!(c > m.right || e < m.left || v > m.bottom || t < m.top)) return !1 } for (x = 0; x < l.series.length; x += 1)if (v = l.series[x], m = v.interpolatedPoints, v.visible && m) {
                for (e = 1; e < m.length; e += 1) {
                    if (m[e].chartX >= c - 16 && m[e - 1].chartX <= c + a.width + 16) {
                        if (w(c, d, a.width, a.height, m[e - 1].chartX, m[e - 1].chartY, m[e].chartX,
                            m[e].chartY)) return !1; this === v && !g && k && (g = w(c - 16, d - 16, a.width + 32, a.height + 32, m[e - 1].chartX, m[e - 1].chartY, m[e].chartX, m[e].chartY))
                    } if ((h || g) && (this !== v || n)) { t = c + a.width / 2 - m[e].chartX; var u = d + a.height / 2 - m[e].chartY; f = Math.min(f, t * t + u * u) }
                } if (!n && h && this === v && (k && !g || f < Math.pow(this.options.label.connectorNeighbourDistance, 2))) {
                    for (e = 1; e < m.length; e += 1)if (g = Math.min(Math.pow(c + a.width / 2 - m[e].chartX, 2) + Math.pow(d + a.height / 2 - m[e].chartY, 2), Math.pow(c - m[e].chartX, 2) + Math.pow(d - m[e].chartY, 2), Math.pow(c +
                        a.width - m[e].chartX, 2) + Math.pow(d - m[e].chartY, 2), Math.pow(c + a.width - m[e].chartX, 2) + Math.pow(d + a.height - m[e].chartY, 2), Math.pow(c - m[e].chartX, 2) + Math.pow(d + a.height - m[e].chartY, 2)), g < b) { b = g; var p = m[e] } g = !0
                }
            } return !k || g ? { x: c, y: d, weight: f - (p ? b : 0), connectorPoint: p } : !1
        }; E.prototype.drawSeriesLabels = function () {
            var c = this, d = this.labelSeries; c.boxesToAvoid = []; d.forEach(function (a) { a.interpolatedPoints = a.getPointsOnGraph(); (a.options.label.boxesToAvoid || []).forEach(function (a) { c.boxesToAvoid.push(a) }) }); c.series.forEach(function (a) {
                function d(a,
                    b, c) { var d = Math.max(h, A(y, -Infinity)), e = Math.min(h + u, A(z, Infinity)); return a > d && a <= e - c.width && b >= l && b <= l + m - c.height } if (a.xAxis || a.yAxis) {
                        var f = [], b, g, n = a.options.label, h = (g = c.inverted) ? a.yAxis.pos : a.xAxis.pos, l = g ? a.xAxis.pos : a.yAxis.pos, u = c.inverted ? a.yAxis.len : a.xAxis.len, m = c.inverted ? a.xAxis.len : a.yAxis.len, e = a.interpolatedPoints, v = A(n.onArea, !!a.area), t = a.labelBySeries, w = !t; var p = n.minFontSize; var q = n.maxFontSize; var r = "highcharts-color-" + A(a.colorIndex, "none"); if (v && !g) {
                            g = [a.xAxis.toPixels(a.xData[0]),
                            a.xAxis.toPixels(a.xData[a.xData.length - 1])]; var y = Math.min.apply(Math, g); var z = Math.max.apply(Math, g)
                        } if (a.visible && !a.isSeriesBoosting && e) {
                            t || (a.labelBySeries = t = c.renderer.label(a.name, 0, -9999, "connector").addClass("highcharts-series-label highcharts-series-label-" + a.index + " " + (a.options.className || "") + r), c.renderer.styledMode || t.css(H({ color: v ? c.renderer.getContrast(a.color) : a.color }, a.options.label.style)), p && q && t.css({ fontSize: a.labelFontSize(p, q) }), t.attr({
                                padding: 0, opacity: c.renderer.forExport ?
                                    1 : 0, stroke: a.color, "stroke-width": 1, zIndex: 3
                            }).add()); p = t.getBBox(); p.width = Math.round(p.width); for (g = e.length - 1; 0 < g; --g)v ? (q = e[g].chartX - p.width / 2, r = e[g].chartCenterY - p.height / 2, d(q, r, p) && (b = a.checkClearPoint(q, r, p))) : (q = e[g].chartX + 3, r = e[g].chartY - p.height - 3, d(q, r, p) && (b = a.checkClearPoint(q, r, p, !0)), b && f.push(b), q = e[g].chartX + 3, r = e[g].chartY + 3, d(q, r, p) && (b = a.checkClearPoint(q, r, p, !0)), b && f.push(b), q = e[g].chartX - p.width - 3, r = e[g].chartY + 3, d(q, r, p) && (b = a.checkClearPoint(q, r, p, !0)), b && f.push(b), q = e[g].chartX -
                                p.width - 3, r = e[g].chartY - p.height - 3, d(q, r, p) && (b = a.checkClearPoint(q, r, p, !0))), b && f.push(b); if (n.connectorAllowed && !f.length && !v) for (q = h + u - p.width; q >= h; q -= 16)for (r = l; r < l + m - p.height; r += 16)(b = a.checkClearPoint(q, r, p, !0)) && f.push(b); if (f.length) {
                                    if (f.sort(function (a, b) { return b.weight - a.weight }), b = f[0], c.boxesToAvoid.push({ left: b.x, right: b.x + p.width, top: b.y, bottom: b.y + p.height }), f = Math.sqrt(Math.pow(Math.abs(b.x - t.x), 2), Math.pow(Math.abs(b.y - t.y), 2))) n = { opacity: c.renderer.forExport ? 1 : 0, x: b.x, y: b.y }, e =
                                        { opacity: 1 }, 10 >= f && (e = { x: n.x, y: n.y }, n = {}), a.labelBySeries.attr(H(n, { anchorX: b.connectorPoint && b.connectorPoint.plotX + h, anchorY: b.connectorPoint && b.connectorPoint.plotY + l })).animate(e, w ? .2 * B(a.options.animation).duration : c.renderer.globalAnimation), a.options.kdNow = !0, a.buildKDTree(), a = a.searchPoint({ chartX: b.x, chartY: b.y }, !0), t.closest = [a, b.x - a.plotX, b.y - a.plotY]
                                } else t && (a.labelBySeries = t.destroy())
                        } else t && (a.labelBySeries = t.destroy())
                    }
            }); l.fireEvent(c, "afterDrawSeriesLabels")
        }; G(E, "load", F); G(E,
            "redraw", F)
    }); w(l, "masters/modules/series-label.src.js", [], function () { })
});
//# sourceMappingURL=series-label.js.map