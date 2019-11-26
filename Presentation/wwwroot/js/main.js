 AOS.init({
 	duration: 800,
 	easing: 'slide'
 });

 (function ($) {

 	"use strict";

 	var isMobile = {
 		Android: function () {
 			return navigator.userAgent.match(/Android/i);
 		},
 		BlackBerry: function () {
 			return navigator.userAgent.match(/BlackBerry/i);
 		},
 		iOS: function () {
 			return navigator.userAgent.match(/iPhone|iPad|iPod/i);
 		},
 		Opera: function () {
 			return navigator.userAgent.match(/Opera Mini/i);
 		},
 		Windows: function () {
 			return navigator.userAgent.match(/IEMobile/i);
 		},
 		any: function () {
 			return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
 		}
 	};


 	$(window).stellar({
 		responsive: true,
 		parallaxBackgrounds: true,
 		parallaxElements: true,
 		horizontalScrolling: false,
 		hideDistantElements: false,
 		scrollProperty: 'scroll'
 	});


 	var fullHeight = function () {

 		$('.js-fullheight').css('height', $(window).height());
 		$(window).resize(function () {
 			$('.js-fullheight').css('height', $(window).height());
 		});

 	};
 	fullHeight();

 	// loader
 	var loader = function () {
 		setTimeout(function () {
 			if ($('#ftco-loader').length > 0) {
 				$('#ftco-loader').removeClass('show');
 			}
 		}, 1);
 	};
 	loader();

 	// Scrollax
 	$.Scrollax();

 	var carousel = function () {
 		$('.carousel-testimony').owlCarousel({
 			center: true,
 			loop: true,
 			items: 1,
 			margin: 30,
 			stagePadding: 0,
 			nav: true,
 			navText: ['<span class="ion-ios-arrow-back">', '<span class="ion-ios-arrow-forward">'],
 			responsive: {
 				0: {
 					items: 1
 				},
 				600: {
 					items: 3
 				},
 				1000: {
 					items: 3
 				}
 			}
 		});

 		$('.single-slider').owlCarousel({
 			animateOut: 'fadeOut',
 			animateIn: 'fadeIn',
 			autoplay: true,
 			loop: true,
 			items: 1,
 			margin: 0,
 			stagePadding: 0,
 			nav: true,
 			dots: true,
 			navText: ['<span class="ion-ios-arrow-back">', '<span class="ion-ios-arrow-forward">'],
 			responsive: {
 				0: {
 					items: 1
 				},
 				600: {
 					items: 1
 				},
 				1000: {
 					items: 1
 				}
 			}
 		});

 	};
 	carousel();

 	$('nav .dropdown').hover(function () {
 		var $this = $(this);
 		// 	 timer;
 		// clearTimeout(timer);
 		$this.addClass('show');
 		$this.find('> a').attr('aria-expanded', true);
 		// $this.find('.dropdown-menu').addClass('animated-fast fadeInUp show');
 		$this.find('.dropdown-menu').addClass('show');
 	}, function () {
 		var $this = $(this);
 		// timer;
 		// timer = setTimeout(function(){
 		$this.removeClass('show');
 		$this.find('> a').attr('aria-expanded', false);
 		// $this.find('.dropdown-menu').removeClass('animated-fast fadeInUp show');
 		$this.find('.dropdown-menu').removeClass('show');
 		// }, 100);
 	});


 	$('#dropdown04').on('show.bs.dropdown', function () {
 		console.log('show');
 	});

 	// scroll
 	var scrollWindow = function () {
 		$(window).scroll(function () {
 			var $w = $(this),
 				st = $w.scrollTop(),
 				navbar = $('.ftco_navbar'),
 				sd = $('.js-scroll-wrap');

 			if (st > 150) {
 				if (!navbar.hasClass('scrolled')) {
 					navbar.addClass('scrolled');
 				}
 			}
 			if (st < 150) {
 				if (navbar.hasClass('scrolled')) {
 					navbar.removeClass('scrolled sleep');
 				}
 			}
 			if (st > 350) {
 				if (!navbar.hasClass('awake')) {
 					navbar.addClass('awake');
 				}

 				if (sd.length > 0) {
 					sd.addClass('sleep');
 				}
 			}
 			if (st < 350) {
 				if (navbar.hasClass('awake')) {
 					navbar.removeClass('awake');
 					navbar.addClass('sleep');
 				}
 				if (sd.length > 0) {
 					sd.removeClass('sleep');
 				}
 			}
 		});
 	};
 	scrollWindow();

 	var isMobile = {
 		Android: function () {
 			return navigator.userAgent.match(/Android/i);
 		},
 		BlackBerry: function () {
 			return navigator.userAgent.match(/BlackBerry/i);
 		},
 		iOS: function () {
 			return navigator.userAgent.match(/iPhone|iPad|iPod/i);
 		},
 		Opera: function () {
 			return navigator.userAgent.match(/Opera Mini/i);
 		},
 		Windows: function () {
 			return navigator.userAgent.match(/IEMobile/i);
 		},
 		any: function () {
 			return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
 		}
 	};


 	var counter = function () {

 		$('#section-counter').waypoint(function (direction) {

 			if (direction === 'down' && !$(this.element).hasClass('ftco-animated')) {

 				var comma_separator_number_step = $.animateNumber.numberStepFactories.separator(',')
 				$('.number').each(function () {
 					var $this = $(this),
 						num = $this.data('number');
 					console.log(num);
 					$this.animateNumber({
 						number: num,
 						numberStep: comma_separator_number_step
 					}, 7000);
 				});

 			}

 		}, {
 			offset: '95%'
 		});

 	}
 	counter();

 	var contentWayPoint = function () {
 		var i = 0;
 		$('.ftco-animate').waypoint(function (direction) {

 			if (direction === 'down' && !$(this.element).hasClass('ftco-animated')) {

 				i++;

 				$(this.element).addClass('item-animate');
 				setTimeout(function () {

 					$('body .ftco-animate.item-animate').each(function (k) {
 						var el = $(this);
 						setTimeout(function () {
 							var effect = el.data('animate-effect');
 							if (effect === 'fadeIn') {
 								el.addClass('fadeIn ftco-animated');
 							} else if (effect === 'fadeInLeft') {
 								el.addClass('fadeInLeft ftco-animated');
 							} else if (effect === 'fadeInRight') {
 								el.addClass('fadeInRight ftco-animated');
 							} else {
 								el.addClass('fadeInUp ftco-animated');
 							}
 							el.removeClass('item-animate');
 						}, k * 50, 'easeInOutExpo');
 					});

 				}, 100);

 			}

 		}, {
 			offset: '95%'
 		});
 	};
 	contentWayPoint();


 	// navigation
 	var OnePageNav = function () {
 		$(".smoothscroll[href^='#'], #ftco-nav ul li a[href^='#']").on('click', function (e) {
 			e.preventDefault();

 			var hash = this.hash,
 				navToggler = $('.navbar-toggler');
 			$('html, body').animate({
 				scrollTop: $(hash).offset().top
 			}, 700, 'easeInOutExpo', function () {
 				window.location.hash = hash;
 			});


 			if (navToggler.is(':visible')) {
 				navToggler.click();
 			}
 		});
 		$('body').on('activate.bs.scrollspy', function () {
 			console.log('nice');
 		})
 	};
 	OnePageNav();


 	// magnific popup
 	$('.image-popup').magnificPopup({
 		type: 'image',
 		closeOnContentClick: true,
 		closeBtnInside: false,
 		fixedContentPos: true,
 		mainClass: 'mfp-no-margins mfp-with-zoom', // class to remove default margin from left and right side
 		gallery: {
 			enabled: true,
 			navigateByImgClick: true,
 			preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
 		},
 		image: {
 			verticalFit: true
 		},
 		zoom: {
 			enabled: true,
 			duration: 300 // don't foget to change the duration also in CSS
 		}
 	});

	$('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
		disableOn: 700,
		type: 'iframe',
		mainClass: 'mfp-fade',
		removalDelay: 160,
		preloader: false,

 		fixedContentPos: false
 	});
 	$('.checkin_date').datepicker({
 		'format': 'dd/mm/yyyy',
 		'todayHighlight': 'true',
 		'startDate': '0d',
 		'autoclose': true
 	});
 	$('.checkout_date').datepicker({
		'format': 'dd/mm/yyyy',
		'setDate': $('.checkin_date').val(),
		'startDate': '0d',
		'autoclose': true
	});

 	function addUser() {
 		$("#register").dialog("close");
 		alert("Succesful");
 	}
 	$('.checkin_date').datepicker('setDate', new Date());
 	var dialog, form;
 	$("#register").dialog({
 		autoOpen: false,
 		height: 400,
 		width: 300,
 		modal: true,
 		closeOnEscape: true,
 		buttons: {
 			"Create an account": addUser,
 			Cancel: function () {
 				$(this).dialog("close");
 			}
 		},
 		close: function () {
 			$(this).dialog("close");
 		}
 	});
 	$("#logIn").on("click", function () {
 		console.log();
 		var username = $("#username").val();
 		var password = $("#password").val();
 		if (username == "") {
 			alert("aaa");
 		}
 		$.ajax({
 			type: "POST",
 			url: "/Flight?handler=LogIn",
 			headers: {
 				"XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
 			},
 			contentType: "application/json; charset=utf-8",
 			dataType: "json",
 			// data: JSON.stringify({UserName : username,PassWord: password}),
 			data: JSON.stringify({
 				Username: username,
 				Password: password
 			}),
 			success: function (response) {
 				if ($.trim(response.msg) == "true") {
 					var a = $("#opener");
 					a.html('<span class="ion-ios-person" style="margin-right:5px"></span>' + response.username + '');
 					$("#dialog").dialog("close");
 				} else {
 					alert("Tài khoản hoặc mật khẩu bị sai!");
 				}
 			},
 			failure: function (response) {
 				alert(response);
 			},
 			error: function (xhr) {
 				alert(xhr.status);
 			}
 		});
 	});
 	dialog = $("#dialog").dialog({
 		autoOpen: false,
 		height: 350,
 		width: 320,
 		maxHeight: 350,
 		maxWidth: 320,
 		resizable: false,
 		modal: true,
 		dialogClass: 'myTitleClass',
 		position: 'center',
 		buttons: {
 			Register: {
 				text: "Register",
 				id: "open-register",
 				click: function () {
 					$("#register").dialog("open");
 					$(this).dialog("close");
 				}
 			},
 			Cancel: function () {
 				$(this).dialog("close");
 			}
 		},
 		close: function () {
 			//form[0].reset();
 			$(this).dialog("close")

 		}
 	});
 	$(window).resize(function () {
 		$("#dialog").dialog("option", "position", {
 			my: "center",
 			at: "center",
 			of: window
 		});
 		$("#register").dialog("option", "position", {
 			my: "center",
 			at: "center",
 			of: window
 		});
 	});
 	$("#opener").on("click", function () {
 		$("#dialog").dialog("open");
 	});
 	$("#dialog").dialog("option", "closeOnEscape", true);
 	$(".info-show").on("click", function () {
 		$(".info-show").css("display", "none");
 		$(".info-hide").css("display", "inline-block");
 		$(".fare__details").css("display", "block");
 	});
 	$(".info-hide").on("click", function () {
 		$(".info-hide").css("display", "none");
 		$(".info-show").css("display", "inline-block");
 		$(".fare__details").css("display", "none");
 	})

 	//Autocomplete
 	$("#From").autocomplete({
 		source: '/Index?handler=AirPort',
 	});
 	$("#Where").autocomplete({
 		source: '/Index?handler=AirPort'
 	})
 })(jQuery);