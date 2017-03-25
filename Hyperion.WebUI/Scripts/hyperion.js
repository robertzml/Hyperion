var hyperion = function() {

    var handleLeftNavActive = function($dom) {
		$('ul#left-nav').children().removeClass('active open');	

		var parent = $dom.parent();
		parent.addClass('active open');		

		var li = $dom.closest('li.left-nav-top');
		li.addClass('active open');
		li.find('a').append('<span class="selected"></span>');
		li.find('.arrow').addClass('open');
	};


    return {
        leftNavActive: function($dom) {
			handleLeftNavActive($dom);
		},
    }
}();