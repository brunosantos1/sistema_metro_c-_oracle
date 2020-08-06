var lastWindowWidth;

(function ($, sr) {
    // debouncing function from John Hann
    // http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
    var debounce = function (func, threshold, execAsap) {
        var timeout;

        return function debounced() {
            var obj = this, args = arguments;
            function delayed() {
                if (!execAsap)
                    func.apply(obj, args);
                timeout = null;
            }

            if (timeout)
                clearTimeout(timeout);
            else if (execAsap)
                func.apply(obj, args);

            timeout = setTimeout(delayed, threshold || 100);
        };
    };

    // smartresize 
    jQuery.fn[sr] = function (fn) { return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };

})(jQuery, 'smartresize');

var CURRENT_URL = window.location.href.split('#')[0].split('?')[0],
    $BODY = $('body'),
    $MENU_BUTTON = $('#menu_button'),
    $SIDEBAR_MENU = $('#side-menu'),
    $SIDEBAR_FOOTER = $('.sidebar-footer'),
    $LEFT_COL = $('.left_col'),
    $RIGHT_COL = $('.right_col'),
    $NAV_MENU = $('.nav_menu'),
    $FOOTER = $('footer'),
    $MAIN_CONTAINER = $('#main_container'),

    $DEFAULT_MENU_DESKTOP_CLASSESS = 'col-sm-4 col-md-3 col-lg-2 expanded-bar',
    $HIDDEN_MENU_DESKTOP_CLASSESS = 'hidden-bar',
    $DEFAULT_MAIN_CONTAINER_DESKTOP_CLASSES = 'col-sm-8 col-md-9 col-lg-10',
    $HIDDEN_MAIN_CONTAINER_DESKTOP_CLASSES = 'expanded-content',

    $DEFAULT_MENU_MOBILE_CLASSESS = 'col-xs-12 expanded-bar-mobile',
    $HIDDEN_MENU_MOBILE_CLASSESS = 'hidden-bar-mobile',
    $DEFAULT_MAIN_CONTAINER_MOBILE_CLASSES = 'col-xs-12',
    $HIDDEN_MAIN_CONTAINER_MOBILE_CLASSES = 'expanded-content-mobile',

    $MENU_BUTTON_DEFAULT_ICON = 'fa-bars',
    $MENU_BUTTON_HIDDEN_ICON_DESKTOP = 'fa-angle-double-right',
    $MENU_BUTTON_HIDDEN_ICON_MOBILE = 'fa-bars';

// Sidebar
function init_sidebar() {
    // TODO: This is some kind of easy fix, maybe we can improve this
    var setContentHeight = function () {
        // reset height
        $RIGHT_COL.css('min-height', $(window).height());

        var bodyHeight = $BODY.outerHeight(),
            footerHeight = $BODY.hasClass('footer_fixed') ? -10 : $FOOTER.height(),
            leftColHeight = $LEFT_COL.eq(1).height() + $SIDEBAR_FOOTER.height(),
            contentHeight = bodyHeight < leftColHeight ? leftColHeight : bodyHeight;

        // normalize content
        contentHeight -= $NAV_MENU.height() + footerHeight;

        $RIGHT_COL.css('min-height', contentHeight);
    };

    $SIDEBAR_MENU.find('a').on('click', function (ev) {
        console.log('clicked - sidebar_menu');
        var $li = $(this).parent();

        if ($li.is('.active')) {
            $li.removeClass('active active-sm');
            $('ul:first', $li).slideUp(function () {
                setContentHeight();
            });
        } else {
            // prevent closing menu if we are on child menu
            if (!$li.parent().is('.child_menu')) {
                $SIDEBAR_MENU.find('li').removeClass('active active-sm');
                $SIDEBAR_MENU.find('li ul').slideUp();
            } else {
                if ($BODY.is(".nav-sm")) {
                    $li.parent().find("li").removeClass("active active-sm");
                    $li.parent().find("li ul").slideUp();
                }
            }
            $li.addClass('active');

            $('ul:first', $li).slideDown(function () {
                setContentHeight();
            });
        }
    });

    // toggle small or large menu 
    $MENU_BUTTON.on('click', function () {
        triggerMenu();
    });

    // check active menu
    $SIDEBAR_MENU.find('a[href="' + CURRENT_URL + '"]').parent('li').addClass('current-page');

    $SIDEBAR_MENU.find('a').filter(function () {
        return this.href == CURRENT_URL;
    }).parent('li').addClass('current-page').parents('ul').slideDown(function () {
        setContentHeight();
    }).parent().addClass('active');

    // recompute content when resizing
    $(window).smartresize(function () {
        setContentHeight();
    });

    setContentHeight();

    // fixed sidebar
    if ($.fn.mCustomScrollbar) {
        $('.menu_fixed').mCustomScrollbar({
            autoHideScrollbar: true,
            theme: 'minimal',
            mouseWheel: { preventDefault: true }
        });
    }
};
// /Sidebar


function triggerMenu(visible) {
    var bar_state = visible != undefined ? !visible : (($MENU_BUTTON.attr('state') != undefined ? $MENU_BUTTON.attr('state') : 'true') == 'true');

    //mobile
    if (isViewstateMobile()) {
        $SIDEBAR_MENU.removeClass($HIDDEN_MENU_DESKTOP_CLASSESS);
        $SIDEBAR_MENU.removeClass($DEFAULT_MENU_DESKTOP_CLASSESS);
        $MAIN_CONTAINER.removeClass($HIDDEN_MAIN_CONTAINER_DESKTOP_CLASSES);
        $MENU_BUTTON.find('i').removeClass($MENU_BUTTON_HIDDEN_ICON_DESKTOP);

        $SIDEBAR_MENU.removeClass(bar_state ? $DEFAULT_MENU_MOBILE_CLASSESS : $HIDDEN_MENU_MOBILE_CLASSESS);
        $SIDEBAR_MENU.addClass(bar_state ? $HIDDEN_MENU_MOBILE_CLASSESS : $DEFAULT_MENU_MOBILE_CLASSESS);

        $SIDEBAR_MENU.contents().toggle(!bar_state);

        $MAIN_CONTAINER.removeClass(bar_state ? $DEFAULT_MAIN_CONTAINER_MOBILE_CLASSES : $HIDDEN_MAIN_CONTAINER_MOBILE_CLASSES);
        $MAIN_CONTAINER.addClass(bar_state ? $HIDDEN_MAIN_CONTAINER_MOBILE_CLASSES : $DEFAULT_MAIN_CONTAINER_MOBILE_CLASSES);

        $MENU_BUTTON.find('i').removeClass(bar_state ? $MENU_BUTTON_DEFAULT_ICON : $MENU_BUTTON_HIDDEN_ICON_MOBILE);
        $MENU_BUTTON.find('i').addClass(bar_state ? $MENU_BUTTON_HIDDEN_ICON_MOBILE : $MENU_BUTTON_DEFAULT_ICON);

        $MENU_BUTTON.attr('state', !bar_state);
    }
    //desktop
    else {
        $SIDEBAR_MENU.removeClass($HIDDEN_MENU_MOBILE_CLASSESS);
        $SIDEBAR_MENU.removeClass($DEFAULT_MENU_MOBILE_CLASSESS);
        $MAIN_CONTAINER.removeClass($HIDDEN_MAIN_CONTAINER_MOBILE_CLASSES);
        $MENU_BUTTON.find('i').removeClass($MENU_BUTTON_HIDDEN_ICON_MOBILE);

        $SIDEBAR_MENU.removeClass(bar_state ? $DEFAULT_MENU_DESKTOP_CLASSESS : $HIDDEN_MENU_DESKTOP_CLASSESS);
        $SIDEBAR_MENU.addClass(bar_state ? $HIDDEN_MENU_DESKTOP_CLASSESS : $DEFAULT_MENU_DESKTOP_CLASSESS);

        $SIDEBAR_MENU.contents().toggle(!bar_state);

        $MAIN_CONTAINER.removeClass(bar_state ? $DEFAULT_MAIN_CONTAINER_DESKTOP_CLASSES : $HIDDEN_MAIN_CONTAINER_DESKTOP_CLASSES);
        $MAIN_CONTAINER.addClass(bar_state ? $HIDDEN_MAIN_CONTAINER_DESKTOP_CLASSES : $DEFAULT_MAIN_CONTAINER_DESKTOP_CLASSES);

        $MENU_BUTTON.find('i').removeClass(bar_state ? $MENU_BUTTON_DEFAULT_ICON : $MENU_BUTTON_HIDDEN_ICON_DESKTOP);
        $MENU_BUTTON.find('i').addClass(bar_state ? $MENU_BUTTON_HIDDEN_ICON_DESKTOP : $MENU_BUTTON_DEFAULT_ICON);

        $MENU_BUTTON.attr('state', !bar_state);
    }
}

$(document).ready(function () {
    init_sidebar();

    if (isViewstateMobile()) {
        triggerMenu(false);
    }

});

function isViewstateMobile() {
    return $('body').width() < 576;
}

$(window).resize(function () {
    var windowWidth = $('body').width();
    var bar_state = ($MENU_BUTTON.attr('state') != undefined ? $MENU_BUTTON.attr('state') : 'true') == 'true';

    if (isViewstateMobile()) {
        if ($SIDEBAR_MENU.hasClass($DEFAULT_MENU_DESKTOP_CLASSESS)
            || $SIDEBAR_MENU.hasClass($HIDDEN_MENU_DESKTOP_CLASSESS)
            || $MAIN_CONTAINER.hasClass($DEFAULT_MAIN_CONTAINER_DESKTOP_CLASSES)
            || $MAIN_CONTAINER.hasClass($HIDDEN_MAIN_CONTAINER_DESKTOP_CLASSES)) {

            triggerMenu(bar_state);
        }
    } else {
        if ($SIDEBAR_MENU.hasClass($DEFAULT_MENU_MOBILE_CLASSESS)
            || $SIDEBAR_MENU.hasClass($HIDDEN_MENU_MOBILE_CLASSESS)
            || $MAIN_CONTAINER.hasClass($DEFAULT_MAIN_CONTAINER_MOBILE_CLASSES)
            || $MAIN_CONTAINER.hasClass($HIDDEN_MAIN_CONTAINER_MOBILE_CLASSES)) {

            triggerMenu(bar_state);
        }
    }

    lastWindowWidth = windowWidth;
});