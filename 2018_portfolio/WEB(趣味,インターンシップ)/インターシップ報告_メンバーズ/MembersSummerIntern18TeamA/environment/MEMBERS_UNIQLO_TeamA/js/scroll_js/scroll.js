var scroll = new SmoothScroll();
	scroll.animateScroll( anchor, toggle, options || {} );
	
	var scroll = new SmoothScroll();
var options = {};
var smoothScrollWithoutHash = function (selector, settings) {
	
	var clickHandler = function (event) {
		var toggle = event.target.closest( selector );
		if ( !toggle || toggle.tagName.toLowerCase() !== 'a' ) return;
		var anchor = document.querySelector( toggle.hash );
		if ( !anchor ) return;

		event.preventDefault();
		scroll.animateScroll( anchor, toggle, options || {} );
	};

	window.addEventListener('click', clickHandler, false );
};
smoothScrollWithoutHash( 'a[href*="#"]' );