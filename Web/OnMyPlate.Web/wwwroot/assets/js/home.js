$(document).on('click', '.filter-restaurant a, .carousel_nav', function() {

    $(window).trigger('scroll'); // FIX for LAZYLOAD in CAROUSEL 
});

function showFirstSix() {
    var restraurant_count = 0;

    $(".restaurant_carousel .restaurant").each(function() {
        restraurant_count++;
    });

    $(".unhide_all_restaurants").css('visibility', 'visible');
}

function showFirstSixVeriga() {
    var restraurant_count = 0;

    $(".logo_carousel .logo_box").each(function() {
        if (restraurant_count > 2) {
            $(this).css('display', 'none');
        }

        restraurant_count++;
    });

    $(".unhide_all_restaurants_veriga").css('visibility', 'visible');
}

function showFirstSixTabs() {
    // tab Regions

    var restraurant_count = 0;
    $(".region_restaurants .offer").each(function() {
        if (restraurant_count > 5) {
            $(this).css('display', 'none');
        }

        restraurant_count++;
    });

    if (restraurant_count > 5) {
        $(".unhide_all_restaurants_region").css('visibility', 'visible');
    }

    // tab Rating
    var restraurant_count2 = 0;

    $(".popular_restaurants .offer").each(function() {
        if (restraurant_count2 > 5) {
            $(this).css('display', 'none');
        }

        restraurant_count2++;
    });

    $(".unhide_all_restaurants_rating").css({
        visibility: 'hidden'
    });

    //tab Kitchen
    var restraurant_count3 = 0;
    $(".discount_restaurants .restaurant").each(function() {
        if (restraurant_count3 > 5) {
            $(this).css('display', 'none');
        }
        restraurant_count3++;
    });
    $(".unhide_all_restaurants_kitchen").css({
        visibility: 'hidden'
    });
}

function hideTabs() {
    $(".down-restaurant-holder .owl-carousel").each(function() {
        $(this).css('display', 'none');
    });

    $(".down-restaurant-holder .region_restaurants").show();
}

$(document).ready(function() {
    if ($(window).width() < 1000) {
        var filter = $('.filter-menu-wrapper');
        var kitchen_element = filter.find('#kitchen');
        var music_element = filter.find('#music_style');
        var map_btn = filter.find('#filter_map_btn');
        // console.log(kitchen_element);

        $("#kitchen").remove();
        $('#music_style').remove();
        $('#filter_map_btn').remove();
        kitchen_element.insertAfter('#for_hour');
        music_element.insertAfter("#kitchen");
        map_btn.prependTo('#more_options_wrapper');
    }
    // Това бихме искали да избегнем за вбъдеще. За сега остава.. MD 16.10.18

    setTimeout(function() {
        hideTabs();
    });

    $(document).on('click', '#main_tab_restaurants, #main_tab_clubs', function(e) {
        e.preventDefault();
        switchMainTabs($(this));
    });

    $(document).on('click', '.subtablinks', function(e) {
        e.preventDefault();
        if ($(this).hasClass('lock')) {
            return false;
        }
        switchSubTabs($(this));
    });

    var cube_wrapper_height = $('.cube_wrapper').height();
    var active_tab = $('.subtablinks.popular');
    var restaurant_carousel_height = $('.restaurant_carousel').height();

    $('.subtablinks.popular').on('click', function() {
        $('.cube_wrapper').css('height', restaurant_carousel_height);

        setTimeout(function() {

            restaurant_carousel_height = $('#ajax_container_popular .restaurant_carousel').height();

        }, 2000);

        active_tab = $(this);
    });

    $('.subtablinks.new').on('click', function() {

        // var myClass = $(active_tab).attr("class");

        // alert("last clicked: " + myClass);

        // alert(myClass + "rest_carousel_height.: " + restaurant_carousel_height);

        $('.cube_wrapper').css('height', restaurant_carousel_height);

        setTimeout(function() {

            restaurant_carousel_height = $('#ajax_container_new .restaurant_carousel').height();

        }, 2000);

        active_tab = $(this);
    });

    $('.subtablinks.biggest_promo').on('click', function() {

        // var myClass = $(active_tab).attr("class");

        // alert("last clicked: " + myClass);

        // alert(myClass + "rest_carousel_height.: " + restaurant_carousel_height);

        $('.cube_wrapper').css('height', restaurant_carousel_height);

        setTimeout(function() {

            restaurant_carousel_height = $('#ajax_container_biggest_promo .restaurant_carousel').height();

        }, 2000);

        active_tab = $(this);
    });

    $('.subtablinks.quick_res').on('click', function() {

        // var myClass = $(active_tab).attr("class");

        // alert("last clicked: " + myClass);

        // alert(myClass + "rest_carousel_height.: " + restaurant_carousel_height);

        $('.cube_wrapper').css('height', restaurant_carousel_height);

        setTimeout(function() {

            restaurant_carousel_height = $('#ajax_container_quick_res .restaurant_carousel').height();

        }, 2000);

        active_tab = $(this);
    });

    // hover effect - show rest restaurants

    $('.view_all_rest_button').hover(
        function() {
            $(this).addClass("hover")
        },

        function() {
            $(this).removeClass("hover")
        }
    );

    $('.link-wrapper').on('click', function() {
        $(this).closest('.restaurant').css("background-color", "#f1f1f1");
    });

    $.cookie('object_type', 0);

    // Проверка дали има "клубове"

    // Transfered from view
    $('#main_tab_clubs').click(function(e) {
        e.preventDefault();
        $('.owl-wrapper').trigger('owl.goTo', 3);
    });

    $('#main_tab_restaurants').click(function(e) {
        e.preventDefault();
        $('.owl-wrapper').trigger('owl.goTo', 0);
    });

    $('#withOfferMobile').click(function(e) {
        e.preventDefault();
        if ($(".offer").offset() !== undefined) {
            document.querySelector('.offer_section a').scrollIntoView({
                behavior: 'smooth',
                block: "start"
            });
        }
    });

    $('#withEventMobile').click(function(e) {
        e.preventDefault();
        if ($(".offers_section").offset() !== undefined) {
            document.querySelector('.section_events a').scrollIntoView({
                behavior: 'smooth',
                block: "start"
            });
        }
    });

    $('#main_tab_theaters').click(function(e) {
        var href = $(this).attr('data-href');
        window.location = href;
    });

    $(document).on('click', '#search_results a.set_region', function() {
        $('#search_restaurant').val($(this).find('.text').text());

        $('#search_results').hide();
    });

    $('#select_region').on('change', function() {
        $('#select_region').selectpicker('render');

        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).closest('#select_region').find('span.label').text('').css({
                display: 'block',
                height: '31px'
            });
        }
    });

    $('#price_filter').on('change', function() {
        $('#price_filter').selectpicker('render');
        $('#price_filter').parent().find('span.label').text(lang_prices);

        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).closest('#price_filter').find('span.label').text('').css({
                display: 'block',
                height: '31px'
            });
        }
    });

    $('#suitable_filter').on('change', function() {
        $('#suitable_filter').selectpicker('render');
        $('#suitable_filter').parent().find('span.label').text(lang_good_for2);

        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).closest('#suitable_filter').find('span.label').text('').css({
                display: 'block',
                height: '31px'
            });
        }
    });

    $('#select_kitchen').on('change', function() {
        $('#music').removeClass('changed').val('');
        $('#music').selectpicker('render');
        $('#music').parent().find('span.label').text(lang_music_style);

        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).closest('#kitchen').find('span.label').text('').css({
                display: 'block',
                height: '31px'
            });
        }
    });

    $('#typesss').on('change', function() {
        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).closest('#choose_type_wrapper').find('span.label').text('').css({
                display: 'block',
                height: '31px'
            });
        }

        if ($(this).val() == 'restaurant') {
            $('#kitchen').show();
            $('#select_kitchen').prop("disabled", false);
            $('#music_style').hide();
            $('#music').prop("disabled", true);
            $('#search').attr('action', url_lang + '/' + city + '/search');
            $('#search_restaurant').attr('placeholder', lang_search_for);

            $('.music__select__container').addClass('select__type__hidden');
            $('.kitchen__select__container').removeClass('select__type__hidden');

            $('#slideshow.owl-carousel').trigger('owl.goTo', 0);
        } else {
            $('#kitchen').hide();
            $('#select_kitchen').prop("disabled", true);
            $('#music_style').show();

            $('#music').prop("disabled", false);
            $('#search').attr('action', url_lang + '/' + city + '/search/clubs');
            $('#search_restaurant').attr('placeholder', lang_search_for);

            $('.music__select__container').removeClass('select__type__hidden');
            $('.kitchen__select__container').addClass('select__type__hidden');

            $('#slideshow.owl-carousel').trigger('owl.goTo', 1);
        }
    });


    $('#music').on('change', function() {
        $('#select_kitchen').removeClass('changed').val('');
        $('#select_kitchen').selectpicker('render');
        $('#select_kitchen').parent().find('span.label').text(lang_kitchen);

        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).closest('#music_style').find('span.label').text('').css({
                display: 'block',
                height: '31px'
            });
        }
    });


    /** It has the same piece of code in head.php at line ~820 */
    $('#select_for_hour').on('change', function() {
        $(this).parent().find('.label').hide();
        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).prev('span.label').text(lang_hour);
        }
    });

    $('#select_seats_number').on('change', function() {
        if (!$(this).hasClass('changed')) {
            $(this).addClass('changed');
            $(this).closest('#seats_number').find('span.label').text('').css({
                display: 'block',
                height: '31px'
            });
        }
    });

    document.cookie = "reserveNow=false; path=/";
    document.cookie = "setVoucher=''; path=/";
    document.cookie = "setEvent=''; path=/";

    $(document).on('click', '.reserveNow', function(e) {
        document.cookie = "reserveNow=true";
    });

    $(document).on('click', '.offers_section .event-main', function(e) {
        var offerId = $(this).attr('data-offer');
        console.log(offerId)
        document.cookie = "setVoucher=" + offerId;
    });

    $(document).on('click', '.event-main ', function(e) {
        var eventId = $(this).attr('data-id');
        console.log(eventId)
        document.cookie = "setEvent=" + eventId;
    });
    // Transfered from view ^^
});

var mainTabChanged = false;

function switchMainTabs(element) {
    if (!element.hasClass('active1')) {
        // remove active1 class

        $('.tablinks').removeClass('active1');

        // add active1 class only on current clicked element

        element.addClass('active1');

        // set global flag to true

        mainTabChanged = true;

        if (element.attr('id') == 'main_tab_clubs') {

            $.cookie('object_type', 1);

            $('.view_all_rest_button1').attr('href', url_lang + '/' + city + '/search/clubs?h=all');

        } else {

            $.cookie('object_type', 0);

            $('.view_all_rest_button1').attr('href', url_lang + '/' + city + '/search?h=all');

        }

        // get active sub tab

        var active_sub_tab = $('.sub_tabs').find('.active');

        // hide all subtabcontent

        $('.subtabcontent').hide();

        // empty all subtab contents

        $('.subtabcontent .restaurant_carousel').html('');



        // fill contents

        if (active_sub_tab.hasClass('popular')) {

            // here need ajax to fill content

            fillContent('getContentPopular');

        } else if (active_sub_tab.hasClass('new')) {

            // here need ajax to fill content

            fillContent('getContentNew');

        } else if (active_sub_tab.hasClass('biggest_promo')) {

            // here need ajax to fill content

            fillContent('getContentBiggestDiscount');

        } else {

            // here need ajax to fill content

            fillContent('getContentFastRestaurants');
        }
    }
}

function switchSubTabs(element) {
    if (!element.hasClass('active')) {
        // remove active class
        $('.subtablinks').removeClass('active');

        // hide all subtabcontent
        $('.subtabcontent').hide();

        // set active class on current element
        element.addClass('active');

        // check element class
        if (element.hasClass('popular')) {
            // check is empty subcontent
            if (isEmpty($('#ajax_container_popular .restaurant_carousel'))) {
                // call ajax to fill content
                fillContent('getContentPopular');
            } else {
                // just show content
                $('#ajax_container_popular').show();
            }
        } else if (element.hasClass('new')) {
            // check is empty subcontent
            if (isEmpty($('#ajax_container_new .restaurant_carousel'))) {
                // call ajax to fill content
                fillContent('getContentNew');
            } else {
                // just show content
                $('#ajax_container_new').show();
            }
        } else if (element.hasClass('biggest_promo')) {
            // check is empty subcontent
            if (isEmpty($('#ajax_container_biggest_promo .restaurant_carousel'))) {
                // call ajax to fill content
                fillContent('getContentBiggestDiscount');
            } else {
                // just show content
                $('#ajax_container_biggest_promo').show();
            }
        } else {
            // check is empty subcontent
            if (isEmpty($('#ajax_container_quick_res .restaurant_carousel'))) {
                // call ajax to fill content
                fillContent('getContentFastRestaurants');
            } else {
                // just show content
                $('#ajax_container_quick_res').show();
            }
        }
    }
}

function isEmpty(el) {
    return !$.trim(el.html());
}

function fillContent(method) {
    // show loading spinner
    // $('.sk-cube-grid').show();
    $('.cube_wrapper').show();

    // lock all sub tabs

    $('.subtablinks').addClass('lock');

    // return false;

    var object_type = 0;
    var extra_club_data = '';
    if ($('#main_tab_clubs').hasClass('active1')) {
        extra_club_data = '/clubs';
        object_type = 1;
    }

    var postData = {
        object_type: object_type
    };

    $.ajax({
        type: "POST",
        url: url_lang + "/" + city + "/home/" + method,
        dataType: 'json',
        data: postData,
        jsonp: "callback",
        async: true,
        cache: false,
        success: function(data) {
            // hide loading spinner
            // $('.sk-cube-grid').hide();
            $('.cube_wrapper').hide();

            // unlock subtabs
            $('.subtablinks').removeClass('lock');

            if (method == 'getContentPopular') {
                $('.view_all_rest_button1').attr('href', url_lang + '/' + city + '/search' + extra_club_data + '?h=all');
                $('#ajax_container_popular .restaurant_carousel').html(data.html);

                $('#ajax_container_popular').show();
            } else if (method == 'getContentNew') {
                $('.view_all_rest_button1').attr('href', url_lang + '/' + city + '/search' + extra_club_data + '?h=all&sort=new');
                $('#ajax_container_new .restaurant_carousel').html(data.html);

                $('#ajax_container_new').show();

            } else if (method == 'getContentBiggestDiscount') {
                $('.view_all_rest_button1').attr('href', url_lang + '/' + city + '/search' + extra_club_data + '?h=all&sort=biggest_discount');
                $('#ajax_container_biggest_promo .restaurant_carousel').html(data.html);

                $('#ajax_container_biggest_promo').show();

                // numItems3 = $('#ajax_container_biggest_promo .restaurant').length;
                // setTimeout(function(){ 
                // 	alert(numItems3); 
                // }, 1500);

                // if(numItems3 < 6) {
                // 	$('.cube_wrapper').css('min-height', '300px');
                // }

            } else {
                $('.view_all_rest_button1').attr('href', url_lang + '/' + city + '/search' + extra_club_data + '?h=all');
                $('#ajax_container_quick_res .restaurant_carousel').html(data.html);

                $('#ajax_container_quick_res').show();

                // numItems4 = $('#ajax_container_quick_res .restaurant').length;
                // setTimeout(function(){ 
                // 	alert(numItems4); 
                // }, 1500);
            }

            if (mainTabChanged) {
                mainTabChanged = false;
                $('.view_all_rest_button1 h4').html(data.see_all_text);
            }

        },

        error: function(xhr, settings, exception) {
            $('.error_message').text(error_occured);

            $('.error_message').show();

        }
    });
}

// Transfered from View 
$('#search_restaurant').keypress(function(event) {
    if (event.keyCode == 13) {
        $('.btn_site_search').trigger('click');
    }
});

// $('form#search').submit(function(e){
// 	e.preventDefault();

// 	var result = { };
// 	result['kitchen_filter'] = [];
// 	result['music_filter'] = [];
// 	$.each($('form#search').serializeArray(), function() {
// 		if(this.name == 'kitchen_filter' || this.name == 'music_filter')
// 		{
// 			result[this.name].push(this.value);
// 		}
// 		else
// 		{
// 			result[this.name] = this.value;
// 		}
// 	});

// 	var prepare_search_kitchen = [];
// 	var prepare_search_neighbourhood = [];
// 	var prepare_search_prices = [];
// 	var prepare_search_good_for = [];
// 	var prepare_search_music = [];
// 	var prepare_search_rest_title = [];
// 	var prepare_search_map = [];
// 	var prepare_search_date = [];
// 	var prepare_search_h = 'all';
// 	var prepare_sort = [];
// 	var prepare_search_p = [];
// 	var show_all = [];



// 	if(typeof result['search__restaurant'] != "undefined" && result['search__restaurant'].length > 0)	prepare_search_rest_title = result['search__restaurant'];
// 	if(result['p'] != '')	prepare_search_p = result['p'];
// 	if(result['date'] != '')	prepare_search_date = result['date'];
// 	if(result['h'] != '')	prepare_search_h = result['h'];
// 	if(typeof result['music_filter'] != 'undefined' && result['music_filter'] != '')	prepare_search_music =result['music_filter'];
// 	if(typeof result['kitchen_filter'] != 'undefined' && result['kitchen_filter'] != '')	prepare_search_kitchen = result['kitchen_filter'];
// 	if(typeof result['neighbourhood[]'] != 'undefined' && result['neighbourhood[]'] != '')	prepare_search_neighbourhood.push(result['neighbourhood[]']);
// 	if(typeof result['prices[]'] != 'undefined' && result['prices[]'] != '')	prepare_search_prices.push(result['prices[]']);
// 	if(typeof result['good_for[]'] != 'undefined' && result['good_for[]'] != '')	prepare_search_good_for.push(result['good_for[]']);
// 	if(result['map'] != 'off')	{prepare_search_map = result['map']; prepare_sort = 'nearest'};

// 	if(prepare_search_h == 'all' && (prepare_search_p == '' || prepare_search_p == 2)) show_all = true;

// 	new_location=jQuery.param({
// 		cuisine: prepare_search_kitchen, 
// 		neighbourhood: prepare_search_neighbourhood, 
// 		prices: prepare_search_prices, 
// 		good_for: prepare_search_good_for, 
// 		music: prepare_search_music, 
// 		rest_name: prepare_search_rest_title, 
// 		sort: prepare_sort,
// 		p: prepare_search_p, 
// 		date: prepare_search_date, 
// 		h: prepare_search_h, 
// 		map: prepare_search_map,
// 		show_all: show_all,
// 		limit: 24
// 	});

// 	window.location = window.location.protocol+'//'+window.location.hostname+$('form#search').attr('action')+'?'+new_location;
// });
// Transfered from View ^^