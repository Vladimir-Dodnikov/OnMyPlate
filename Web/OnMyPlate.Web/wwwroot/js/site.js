//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.

//var map_timeout2 = null;

//var user_loged = false;
//var free_user = false;
//var free_user2 = false;

//if ($.cookie('go_free') == '1') {
//	free_user = true;
//	console.log(free_user);
//}

//free_user2 = true;

//// $(document).on('change', '.restaurant-halls', function(){
//$(document).on('change', 'input[type="radio"][name="hall_id"]', function () {

//	$.ajax({
//		type: "POST",
//		url: "/r/getHallExtras/" + $(this).val(),
//		dataType: 'json',
//		data: '',
//		jsonp: "callback",
//		async: true,
//		cache: false,
//		success: function (data) {
//			// if(data.extras.length != 0){
//			$('input.extras').prop('disabled', true);
//			$('input.extras').removeAttr('checked');
//			$('input.extras').each(function () {
//				$(this).next("label").addClass('disabled');
//				$(this).next("label").removeClass('checked');
//				if ($.inArray($(this).val(), data.extras) != -1) {
//					$(this).prop('disabled', false);
//					$(this).next("label").removeClass('disabled');
//				}
//			});
//			// }
//		},
//		error: function (xhr, settings, exception) {
//			// console.log(xhr+" "+settings+" "+exception);
//		}
//	});
//});

//function getAvailableHalls(e) {

//	var fast_reservation = false;
//	var data_party = 0;
//	var data_mins = 0;

//	if ($(e).hasClass('fast_reservation')) {
//		fast_reservation = true;
//	}

//	var r_id = 1016;
//	if ($('ul.tab-boxes li.active').hasClass('birthday')) {
//		var date = $('input.datepicker').val();
//		var date_arr = date.split(' | ');
//		date = date_arr[0] + '/' + date_arr[1] + '/' + date_arr[2];
//		// var hour = $('#birthday_hour').val();
//		var hour = $(e).find('.hour').html();
//	} else {
//		var date = $('input.datepicker').val();
//		var date_arr = date.split(' | ');
//		date = date_arr[0] + '/' + date_arr[1] + '/' + date_arr[2];
//		var hour = $(e).find('.hour').html();
//		data_party = $(e).attr('data-party');
//		data_mins = $(e).attr('data-mins');
//	}

//	var reservation_type = $('ul.tab-boxes li.active').data('res_type');

//	var postData = { r_id: r_id, date: date, hour: hour, reservation_type: reservation_type };

//	var result = [];
//	var ajax_method = 'getAvailableHalls';

//	if (fast_reservation) { // FAST RESERVATION AJAX AND DATA
//		ajax_method = 'getAvailableFastHalls';
//		postData = { r_id: r_id, data_party: data_party, data_mins: data_mins, reservation_type: reservation_type };
//	}

//	$.ajax({
//		type: "POST",
//		url: "/en/r/" + ajax_method,
//		dataType: 'json',
//		data: postData,
//		jsonp: "callback",
//		async: false,
//		cache: false,
//		success: function (data) {

//			if (data.success) {
//				result = data.available_halls;
//			} else {
//				// alert("ERROR");
//			}
//		},
//		error: function (xhr, settings, exception) {
//			//alert('config-error:' +xhr.responseText);
//		}
//	});

//	// console.log(result);

//	return result;
//}

//$(document).on('click', '.guarantee', function () {

//	var postData = { controller: 'discount_garantee' };

//	$.ajax({
//		type: "POST",
//		// url: "http://"+location.hostname+"/en/sofia/home/getGuarantee",
//		url: "/en/sofia/home/getGuarantee",
//		dataType: 'json',
//		data: postData,
//		jsonp: "callback",
//		async: true,
//		cache: false,
//		success: function (data) {

//			if (data.success) {

//				$('#msg_title_popup').html('Re<b style="color:#d70008;">ZZ</b>o.bg guaranty');
//				$('#msg_body_popup').html('<div style="color: #000000; font-family: Helvetica Neue, Helvetica, Arial, sans-serif">' + data.page_obj_description + '</div>');
//				centerPopup('home_buttons_popup');
//				$('#mask').fadeTo(250, 0.56);
//				$("#home_buttons_popup").fadeIn(250);
//				$('.popup_bottom').scrollTop(0);
//			} else {

//			}
//		},
//		error: function (xhr, settings, exception) {
//			//alert('config-error:' +xhr.responseText);
//		}
//	});
//});

//function makeReservation() {

//	// var url = "http://"+location.hostname+"/en/user/makeReservation";
//	var url = "/en/user/makeReservation";
//	var data = $("#reservation_form").serializeArray();

//	// console.log(data);


//	if ($("#reservation_form").validationEngine('validate') == true) {

//		$('#telephone').unmask('+(000) 000-000-000');
//		$('#telephone').val($('#telephone').cleanVal());

//		data = $("#reservation_form").serializeArray();

//	} else {
//		$('.make_reservation_button').prop('disabled', false);
//		return false;
//	}

//	closeModalDialog();
//	$.ajax({
//		type: "POST",
//		url: url,
//		dataType: 'json',
//		data: data,
//		jsonp: "callback",
//		async: true,
//		cache: false,
//		success: function (data) {

//			if (data.success === false) {

//				openModalDialog('Message', '' + data.error_message + '', 'OK', 'closeModalDialog', '');
//				if (data.err_type == 12) {
//					//$('#common_msg').attr('data-reload','true');
//					$('#common_msg').addClass('reload');
//				} else {

//					findTable();

//				}

//			} else {
//				if (data.params != undefined) {
//					// window.location = "http://"+location.hostname+"/en/"+data.contr+"/lastReservation/"+data.params;
//					window.location = "/en/" + data.contr + "/lastReservation/" + data.params;
//				} else {
//					// window.location = "http://"+location.hostname+"/en/"+data.contr+"/lastReservation/"+data.reservation_id;
//					window.location = "/en/" + data.contr + "/lastReservation/" + data.reservation_id;
//				}
//				//redirect to profile last reservation
//			}


//		},
//		error: function (xhr, settings, exception) {
//			//alert('config-error:' +xhr.responseText);
//			// Нещо се обърка. Моля презаредете страницата. Ако грешката се повтаря свържете със нас за съдействие.

//			var error_info = '';

//			if (xhr.status === 0) {
//				error_info += 'Not connect.\n Verify Network.';
//			} else if (xhr.status == 404) {
//				error_info += 'Requested page not found. [404]';
//			} else if (xhr.status == 500) {
//				error_info += 'Internal Server Error [500].';
//			} else if (exception === 'parsererror') {
//				error_info += 'Requested JSON parse failed.';
//			} else if (exception === 'timeout') {
//				error_info += 'Time out error.';
//			} else if (exception === 'abort') {
//				error_info += 'Ajax request aborted.';
//			}

//			error_info += '\n response: ' + xhr.responseText;

//			openModalDialog('Message', 'An error has occurred. Please reload the page. If the error is repeated contact us for assistance.', 'OK', 'closeModalDialog', '');

//			var errdata = { error_info: error_info };

//			$.ajax({
//				type: "POST",
//				// url: "http://"+location.hostname+"/external/error_report",				
//				url: "/external/error_report",
//				dataType: 'json',
//				data: errdata,
//				jsonp: "callback",
//				async: true,
//				cache: false
//			});

//		}
//	});
//}

//function addToFavourites() {

//	var rest_id = 1016;

//	$.ajax({
//		type: "POST",
//		// url: "http://"+location.hostname+"/en/sofia/r/addToFavourites/"+rest_id,				
//		url: "/en/sofia/r/addToFavourites/" + rest_id,
//		dataType: 'json',
//		jsonp: "callback",
//		async: true,
//		cache: false,
//		success: function (data) {

//			if (data.success) {
//				openModalDialog('Message', 'The restaurant was added to <a href="/en/profile/favourite_restaurants">favorites</a>.', 'OK', 'closeModalDialog', '');
//				$('.add_to_favourites').css('display', 'none');
//				$('.remove_from_favourites').css('display', 'block');
//				fbq('track', 'AddToWishlist');
//			}
//			else {
//				openModalDialog('Message', data.error, 'OK', 'openLoginPop', '');
//			}

//		},
//		error: function (xhr, settings, exception) {
//			openModalDialog('Message', 'An error occurred, please try again.', 'OK', 'closeModalDialog', '');
//		}
//	});

//}

//function removeRestFromFavourites() {

//	var rest_id = 1016;

//	$.ajax({
//		type: "POST",
//		// url: "http://"+location.hostname+"/en/sofia/r/removeFromFavourites/"+rest_id,				
//		url: "/en/sofia/r/removeFromFavourites/" + rest_id,
//		dataType: 'json',
//		jsonp: "callback",
//		async: true,
//		cache: false,
//		success: function (data) {

//			if (data.success) {
//				openModalDialog('Message', 'The restaurant has been removed from favorites.', 'OK', 'closeModalDialog', '');
//				$('.add_to_favourites').css('display', 'block');
//				$('.remove_from_favourites').css('display', 'none');
//			}
//			else {
//				openModalDialog('Message', data.error, 'OK', 'closeModalDialog', '');
//			}
//		},
//		error: function (xhr, settings, exception) {
//			openModalDialog('Message', 'An error occurred, please try again.', 'OK', 'closeModalDialog', '');
//		}
//	});
//}



//$(document).ready(function () {

//	var owl4 = $(".restaurant_slideshow_holder_up .restaurant_slideshow");
//	var owl5 = $("#offers_carousel");
//	var i = 1;
//	var total_pages = 4;
//	var images_arr = [];
//	images_arr = { "1": { "url": "files\/images\/3846\/fit_431_304.jpg", "alt": "Photo 1" }, "2": { "url": "files\/images\/3847\/fit_431_304.jpg", "alt": "Photo 2" }, "3": { "url": "files\/images\/4025\/fit_431_304.jpg", "alt": "Photo 3" }, "4": { "url": "files\/images\/8394\/fit_431_304.jpg", "alt": "" } };

//	showFirstFourComments();
//	verticalAlignBoxes();
//	owl4.owlCarousel({

//		singleItem: true,
//		responsiveBaseWidth: $(".restaurant_slideshow_holder_up"),
//		navigation: true, // Show next and prev buttons
//		slideSpeed: 300,
//		paginationSpeed: 400,
//		navigation: false,
//		pagination: true,
//		afterInit: function () {

//			$('.restaurant_slideshow_holder_up .restaurant_slideshow .owl-pagination .owl-page').each(function (index) {

//				$(this).find('span').addClass('red_border');
//				if (images_arr.length === 0) {
//					$(this).append('<img src="/assets/images/none.jpg" alt="image thumb" width="101px"/>');
//				} else {
//					$(this).append('<img src="/' + images_arr[i].url + '" alt="image thumb" width="101px"/>');
//				}
//				i++;
//				if (index === total_pages - 1) {
//					$(this).addClass('last');
//					i = 1;
//				}
//			});
//			customPagination();
//		},
//		afterUpdate: function () {
//			i = 1;
//			$('.restaurant_slideshow_holder_up .restaurant_slideshow .owl-pagination .owl-page').each(function (index) {
//				$(this).find('span').addClass('red_border');
//				if (images_arr.length === 0) {
//					$(this).append('<img src="/assets/images/none.jpg" alt="image thumb" width="101px"/>');
//				} else {
//					$(this).append('<img src="/' + images_arr[i].url + '" alt="image thumb" width="101px"/>');
//				}
//				i++;
//				if (index === total_pages - 1) {
//					$(this).addClass('last');
//					i = 1;
//				}
//			});

//			customPagination();
//		}
//	});


//	// if(isMobile2() == false){
//	// initialize_restaurant_map();
//	// }


//	if ($.cookie('sofia_my_position')) {
//		calcRoute();
//	}
//	resizeDayBoxes();

//	$('.add_to_favourites').on('click', function () {
//		addToFavourites();
//	});

//	$('.remove_from_favourites').on('click', function () {
//		removeRestFromFavourites();
//	});


//	$('.red_link_button').each(function () {
//		if ($(this).attr('href') == "") {
//			$(this).css('display', 'none'); // HIDE ALL BTNS WITHOUT HREF
//		}
//	});

//	$('.see_more_comment').on('click', function () {
//		var aTag = $(".comments_restaurant_view");
//		$('html,body').animate({ scrollTop: aTag.offset().top }, 'slow');
//	});



//	$(document).on("click", ".day_box_wrapper .no-tables", function (e) {
//		openModalDialog('Message', 'No available tables for this hour', 'ok', 'closeModalDialog');
//	});

//});

//function checDayBoxes() {
//	if ($('.day_box_small').length == 0 && $('.no_freetables').length == 0) {
//		if ($('ul.tab-boxes li.active').hasClass('standart')) {
//			if (mobile_device == true) {
//				$('.day_box_wrapper').prepend('<div class="no_freetables">There are no available tables for the given number of people, date and table location for that type of reservation.<br /></div>');
//			} else {
//				$('.day_box_wrapper').prepend('<div class="no_freetables">There are no available tables for the given number of people, date and table location for that type of reservation.<br /></div>');
//			}
//		} else {
//			if (mobile_device == true) {
//				$('.day_box_wrapper').prepend('<div class="no_freetables">There are no available tables for the given number of people, date and table location for that type of reservation.<br /></div>');
//			} else {
//				$('.day_box_wrapper').prepend('<div class="no_freetables">There are no available tables for the given number of people, date and table location for that type of reservation.<br /></div>');
//			}

//			if ($('ul.tab-boxes li.active').hasClass('discount_all')) {
//				$('#discount_all i p').html('');
//			}

//			if ($('ul.tab-boxes li.active').hasClass('food_discount')) {
//				$('#food_discount i p').html('');
//			}
//		}
//	}
//}

//function findTable() {

//	var id = 1016;
//	var p = 0;
//	var adults = 0;
//	var kids = 0;
//	var hall_id = $('#halls').val();

//	if ($('#side_select_seats_number').val() != '') {
//		p += parseInt($('#side_select_seats_number').val());
//		adults = parseInt($('#side_select_seats_number').val());
//	}

//	if ($('select[name=p_ch]').val() != '') {
//		p += parseInt($('select[name=p_ch]').val());
//		kids = parseInt($('select[name=p_ch]').val());
//	}

//	if (p == 0 || p == '' || p == undefined) {
//		return false;
//	}

//	var reservation_type = $('.tab-boxes li.active').data('res_type');

//	var selected_offers = new Array();
//	var special = false;
//	if (reservation_type == 3) {
//		$('select.offerpicker').each(function () {
//			var temp = {};
//			temp.id = $(this).val();
//			temp.count = $('#' + $(this).attr('for')).val();
//			selected_offers.push(temp);
//			if ($(this).find(':selected').data('config') != '0') {
//				special = true;
//			}
//		});
//	}

//	var date = $('.datepicker').val();
//	var arr = date.split(' | ');

//	date = arr[2] + '-' + arr[1] + '-' + arr[0];

//	var postData = { date: date, p: p, adults: adults, kids: kids, reservation_type: reservation_type, selected_offers: selected_offers, hall_id: hall_id };

//	if (isMobile2()) {
//		$('#preloader').show();
//	} else {
//		var pre_w = $('.bottom_part_content').width();
//		var pre_h = $('.bottom_part_content').height() + 10;
//		$('#preloader_search').css({
//			backgroundColor: '#dadada',
//			height: pre_h + 'px',
//			position: 'absolute',
//			top: '8px',
//			width: pre_w + 'px',
//			zIndex: '999999'

//		}).show();
//	}

//	$.ajax({
//		type: "POST",
//		// url: "http://"+location.hostname+"/en/r/v_ajax/"+id,				
//		url: "/en/r/v_ajax/" + id,
//		dataType: 'json',
//		data: postData,
//		jsonp: "callback",
//		async: true,
//		cache: false,
//		success: function (data) {

//			$('.bottom_part_content').animate({
//				opacity: 0
//			},
//				{
//					easing: 'swing',
//					duration: 300,
//					complete: function () {
//						// if(!$('ul.tab-boxes li.birthday').hasClass('active')){
//						$('.bottom_part_content').html(data.content);

//						if (parseInt(data.best_weekly_discount) > 0) {
//							$('#discount_all i p').html('up to -' + data.best_weekly_discount + '%');
//						} else {
//							$('#discount_all i p').html('');
//						}

//						if (parseInt(data.best_weekly_food_discount) > 0) {
//							$('#food_discount i p').html('up to -' + data.best_weekly_food_discount + '%');
//						} else {
//							$('#food_discount i p').html('');
//						}

//						if ($('.step-3').hasClass('opened')) {

//						} else {
//							$('.step-3').addClass('opened').slideDown(500, function () { $('.step-3').css('overflow', 'visible'); });
//						}

//						var input = $('.datepicker');
//						var picker = input.pickadate('picker');
//						var arr2 = data.date.split('-');

//						var joindate2 = new Date(
//							parseInt(arr2[0], 10),
//							parseInt(arr2[1], 10) - 1,
//							parseInt(arr2[2], 10)
//						);

//						var day2 = joindate2.getDate();
//						var month2 = joindate2.getMonth();
//						var year2 = joindate2.getFullYear();

//						if (day2 < 10) {
//							day2 = '0' + day2;
//						}
//						if (month2 < 10) {
//							month2 = '0' + month2;
//						}

//						var r_data = year2 + '-' + month2 + '-' + day2;

//						if (picker) {
//							picker.set('select', r_data, { format: 'yyyy-mm-dd', muted: true });
//							setNewDate();
//						}
//						resizeDayBoxes();
//						checDayBoxes();
//						$('#preloader_search').hide();

//						setTimeout(function () {
//							$('#preloader').hide();
//						}, 750);


//						$(".bottom_part_content").animate({
//							opacity: 1
//						}, 300);
//						// }
//					}
//				});
//		},
//		error: function (xhr, settings, exception) {
//			//alert('config-error:' +xhr.responseText);
//		}
//	});
//}

//var directionsDisplay;
//var directionsService = new google.maps.DirectionsService();
//var map;

//function initialize_restaurant_map() {

//	var lat = '42.6701768';
//	var lon = '23.2919329';

//	var rest_lat_lng = [];
//	rest_lat_lng.push(lat);
//	rest_lat_lng.push(lon);

//	if ($.cookie('sofia_my_position')) {
//		$('.from-me').text(calcDestination(rest_lat_lng).toFixed(2) + 'km от Вас').show();
//	}
//	//alert(lat+','+lon);
//	if (lat == "" || lon == "") {
//		var myLatlng = new google.maps.LatLng(map_center.sofia[0], map_center.sofia[1]);
//	} else {
//		var myLatlng = new google.maps.LatLng(lat, lon);
//	}

//	var window_width = $(window).width();

//	if (window_width <= 1000) {

//		var restaurant_info_width = $('.container').width();
//		var map_width = restaurant_info_width + 30;
//		$('#restaurant_map').css('width', map_width + 'px');

//	} else {
//		$('#restaurant_map').css('width', '100%');
//	}

//	var map_canvas = document.getElementById('restaurant_map');

//	var map_options = {
//		center: myLatlng,
//		zoom: 17,
//		mapTypeId: google.maps.MapTypeId.ROADMAP,

//	};

//	map = new google.maps.Map(map_canvas, map_options);
//	// off
//	directionsDisplay = new google.maps.DirectionsRenderer({ map: map, suppressMarkers: true });
//	// directionsDisplay.setMap(map);
//	if (!$.cookie('sofia_my_position')) {
//		if (lat != "" || lon != "") {

//			var marker_icon = '/assets/images/map_icons/restaurant_pin_32x32.png';
//			var marker = new google.maps.Marker({
//				position: myLatlng,
//				map: map,
//				icon: marker_icon

//			});
//		}
//	}
//}

//function calcRoute() {
//	if ($.cookie('sofia_my_position')) {
//		var my_pos = JSON.parse($.cookie('sofia_my_position'));
//		var start = my_pos.lat + ',' + my_pos.lng;
//	}

//	var end = '42.6701768,23.2919329';
//	var request = {
//		origin: start,
//		destination: end,
//		travelMode: google.maps.TravelMode.DRIVING
//	};
//	directionsService.route(request, function (result, status) {
//		if (status == google.maps.DirectionsStatus.OK) {
//			// start point marker
//			var marker = new google.maps.Marker({
//				position: result.routes[0].legs[0].steps[0].start_point,
//				map: map,
//				icon: '/assets/images/map_icons/green-dot.png'

//			});

//			var steps_length = result.routes[0].legs[0].steps.length;

//			var marker_icon = '/assets/images/map_icons/restaurant_pin_32x32.png';
//			// start point marker
//			var marker = new google.maps.Marker({
//				position: result.routes[0].legs[0].steps[steps_length - 1].end_point,
//				map: map,
//				icon: marker_icon

//			});

//			// console.log(result);
//			//   directionsDisplay.setDirections(result);
//			//alert(result.routes[0].legs[0].distance.value);//show distance in meters
//		}
//	});
//}

//function resizeDayBoxes() {
//	var window_width = $(window).width();
//	var opened_box_height = $('.opened_day_box .day_box_wrapper').height() - 5;



//	if (window_width > 768) {
//		//alert(">768 "+ window_width);
//		if (opened_box_height < 196) {
//			$('.day_box').each(function () {
//				$(this).css('height', '240px');
//				$(this).find('.day_box_bottom').css({
//					'height': '32%'
//				});
//			});
//			$('.day_box_under_head').css('height', '196px');
//		}
//		else {
//			if (opened_box_height < 395) {
//				$('.day_box').each(function () {
//					$(this).css('height', opened_box_height + 45 + 'px');
//					$(this).find('.day_box_bottom').css({
//						'height': '33%'
//					});
//				});
//			}
//			else {
//				$('.day_box').each(function () {
//					$(this).css('height', opened_box_height + 45 + 'px');
//					$(this).find('.day_box_bottom').css({
//						'height': '33%'
//					});
//				});
//			}

//			$('.day_box_under_head').css('height', opened_box_height + 'px');
//		}
//	}
//	else {
//		//alert("<768");
//		$('.day_box').each(function () {
//			$(this).css('height', 'inherit');
//			$(this).find('.day_box_bottom').css({
//				'height': '84px'
//			});
//		});
//		$('.day_box_under_head').css('height', '87px');
//	}
//}

//function customPagination() {
//	var window_width = $(window).width();

//	if (window_width < 200) {
//		$('.restaurant_slideshow .owl-pagination .owl-page span').each(function (index) {
//			$(this).removeClass('red_border');
//		});
//	}
//}

//function verticalAlignBoxes() {
//	var window_width = $(window).width();
//	var leftbox_height = $('.bottom_restaurant_view .left_part').height();
//	var rightbox_height = $('.bottom_restaurant_view .right_part').height() + 25;



//	if (window_width > 1000) {

//		if (leftbox_height !== rightbox_height && $('.bottom_restaurant_view .right_part').is(':visible')) {

//			if (leftbox_height > rightbox_height) {

//				$('.bottom_restaurant_view .right_part').css('height', leftbox_height + 'px');
//			}
//			else {
//				$('.bottom_restaurant_view .left_part').css('height', rightbox_height + 'px');
//			}
//		}
//	}
//	else {

//	}
//}

//$(window).resize(function () {

//	if (map_timeout2 != null) window.clearTimeout(map_timeout2);

//	map_timeout2 = window.setTimeout(function () {

//		var window_changed = $(window).width() != window.global_width;

//		if (window_changed) {
//			if ($('#restaurant_map').css('display') == 'block') {

//				$('#restaurant_map').fadeOut(200);


//				$('#restaurant_map').fadeIn();
//				window.global_width = $(window).width();
//				if (isMobile2() == false) {
//					initialize_restaurant_map();
//				}

//			}
//		}

//		verticalAlignBoxes();
//		resizeDayBoxes();
//	}, 1000);
//});

//$('.bottom_restaurant_view .right_part .show_hidden_area').on('click', function () {

//	$('.bottom_restaurant_view .right_part').css('height', 'inherit');

//	$('.bottom_restaurant_view .right_part .right_part_overflow').css({
//		'overflow': 'visible',
//		'height': 'inherit'
//	});

//	$(this).hide();

//	verticalAlignBoxes();
//});