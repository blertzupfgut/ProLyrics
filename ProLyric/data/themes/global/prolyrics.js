// More info about config & dependencies:
// - https://github.com/hakimel/reveal.js#configuration
// - https://github.com/hakimel/reveal.js#dependencies
Reveal.initialize({
	dependencies: [
		{ src: 'plugin/markdown/marked.js' },
		{ src: 'plugin/markdown/markdown.js' }
	],				
	
	controls: false,
	controlsTutorial: false,
	progress: false,
	overview: false,
	help: false,
	
	// hideInactiveCursor: true,
	// hideCursorTime: 5000,
	// hideAddressBar: true,
	// embedded: false,
	
	center: false,
	transition: 'none',           // none/fade/slide/convex/concave/zoom
	transitionSpeed: 'fast',      // default/fast/slow
	backgroundTransition: 'none', // none/fade/slide/convex/concave/zoom,
	
	// display: 'block',
	
	// The "normal" size of the presentation, aspect ratio will be preserved
	// when the presentation is scaled to fit different resolutions. Can be
	// specified using percentage units.
	width: 1024,
	height: 768,

	// Factor of the display size that should remain empty around the content
	// margin: 0.1,
	// Bounds for smallest/largest possible scale to apply to content
	// minScale: 0.2,
	// maxScale: 1.5,
	
	width: "100%",
	height: "100%",
	margin: 0,
	minScale: 1,
	maxScale: 1
});

// Reveal.addKeyBinding(82, function() {
// });

// Reveal.configure({
  // keyboard: {
	// // 13: 'next', // go to the next slide when the ENTER key is pressed
	// // 27: function() {}, // do something custom when ESC is pressed
	// 32: null  // don't do anything when SPACE is pressed (i.e. disable default "next" binding)
  // }
// });