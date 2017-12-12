/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};

/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {

/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;

/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};

/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);

/******/ 		// Flag the module as loaded
/******/ 		module.l = true;

/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}


/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;

/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;

/******/ 	// identity function for calling harmony imports with the correct context
/******/ 	__webpack_require__.i = function(value) { return value; };

/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};

/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};

/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };

/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";

/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 2);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {


var slider = __webpack_require__(1);
var gallery = new slider();
var x = 0;
$(window).ready(() => {
    gallery.run();
    let page = $("html, body");
    let mouse_event = "scroll mousedown wheel DOMMouseScroll mousewheel keyup touchmove";

    $("#bt_about").on('click', () => {
        page.on(mouse_event, () => {
            page.stop();
        });

        page.animate({
            scrollTop: $("#about").offset().top - 100
        }, 1000, () => {
            page.off(mouse_event);
        });

        return false;
    });

    $("#bt_service").on('click', () => {
        page.on(mouse_event, () => {
            page.stop();
        });

        page.animate({
            scrollTop: $("#service").offset().top - 100
        }, 1000, () => {
            page.off(mouse_event);
        });

        return false;
    });
    $("#bt_gallery").on('click', () => {
        page.on(mouse_event, () => {
            page.stop();
        });

        page.animate({
            scrollTop: $("#slider_show_gallery").offset().top 
        }, 1000, () => {
            page.off(mouse_event);
        });

        return false;
    });
    $("#bt_contact").on('click', () => {
        page.on(mouse_event, () => {
            page.stop();
        });

        page.animate({
            scrollTop: $("#contact").offset().top - 100
        }, 1000, () => {
            page.off(mouse_event);
        });

        return false;
    });
    $("#icon_bar").on('click', () => {
        ($('#navigation_responsive ul div')).toggle('slow');
    });

  

    $(window).on('scroll', $.throttle(17, () => {
        let layer_1 = window.pageYOffset / 8000;
        let layer_2 = window.pageYOffset / 16000;
        let layer_3 = window.pageYOffset / 32000;
        let opacity = window.pageYOffset / 1500;

        layer_1 = (layer_1 + 1).toFixed(3);
        layer_2 = (layer_2 + 1).toFixed(3);
        layer_3 = (layer_3 + 1).toFixed(3);
       
       

        layer_1 = (layer_1 > 2.1) ? 2.1 : layer_1;
        layer_2 = (layer_2 > 2) ? 2 : layer_2;
        layer_3 = (layer_3 > 1.2) ? 1.2 : layer_3;
          if(window.pageYOffset < $("#service").offset().top + 100)
             opacity = (opacity > 0.5) ? 0.5 : opacity; 
        else
            if(window.pageYOffset >= $("#service").offset().top + 100)
            {
                opacity = 2-opacity;
            }
        $('#window').css('transform', `scale( ${layer_1} , ${layer_1})`);
        $('#house').css('transform', `scale( ${layer_2} , ${layer_2})`);

        $('#effect').css('transform', `scale( ${layer_3} , ${layer_3})`);
        $('#light').css('transform', `scale( ${layer_3} , ${layer_3})`);

        $('#overlay').css('background-color', `rgba(0, 0, 0, ${opacity})`);

        $('#background').css('transform', `scale( ${layer_3} , ${layer_3})`);
    }));
   $(window).on('resize', $.debounce(100, () => {
         
        
    }));

});

let bg_calculator = () => {

    var width = 1920;
    var height = 1200;

    var object = $('#background');
    /* Step 1 - Get the ratio of the div + the image */
    var imageRatio = width / height;
    var coverRatio = object.outerWidth() / object.outerHeight();
    /* Step 2 - Work out which ratio is greater */
    if (imageRatio >= coverRatio) {
        /* The Height is our constant */
        var coverHeight = object.outerHeight();
        var scale = (coverHeight / height);
        var coverWidth = width * scale;
    } else {
        /* The Width is our constant */
        var coverWidth = object.outerWidth();
        var scale = (coverWidth / width);
        var coverHeight = height * scale;
    }
    return {
        width: coverWidth,
        height: coverHeight,
        scale: scale,
        ratio: coverRatio
    };
};

const intro = function(game) {
    this.preload = function() {
        game.add.plugin(Fabrique.Plugins.Spine);
        this.load.image('particle', 'assets/particle.png');
        this.load.spine('caymon', 'assets/taro/TARO11.skel', ['@0.5x']);
        this.load.spine('water', 'assets/waterfall/waterfall11.skel', ['@0.5x']);
    };
    this.create = function() {

        let offset_percentage = 150;
        let caymon = this.add.spine(0, 0, 'caymon');
        caymon.setAnimationByName(0, "windy", true);

        let water = this.add.spine(0, 0, 'water');
        water.setAnimationByName(0, "falling", true);
        water.alpha = 0.2;

        let emitter = this.add.emitter(this.world.centerX + offset_percentage, this.world.centerY, 100);
        emitter.width = 320;
        emitter.height = $(window).height() / 2;
        emitter.makeParticles('particle');
        emitter.minParticleScale = 0.1;
        emitter.maxParticleScale = 0.2;
        emitter.minParticleAlpha = 0.8;
        emitter.maxParticleAlpha = 1;
        emitter.maxParticles = 100;
        emitter.gravity = -1;
        emitter.setYSpeed(-25, 25);
        emitter.setXSpeed(-25, 25);
        emitter.start(false, 5000, 250, 0);
        bg_size = bg_calculator();

        caymon.scale.setTo(0.8 * bg_size.scale);
        caymon.x = $(window).width() / 2 + (220 * bg_size.scale );
        caymon.y = ($(window).height() / 2) + (300*bg_size.scale );
        $(window).on('resize', $.debounce(100, () => {
             let tem = window.pageYOffset / 32000;
             tem = (tem + 1).toFixed(3);
              tem = (tem > 1.2) ? 1.2 : tem;
            bg_size = bg_calculator();
            game.scale.setGameSize($('#effect').outerWidth(), $('#effect').outerHeight());
            caymon.scale.setTo(0.8 *bg_size.scale*tem);
            caymon.x = $(window).width() / 2 + (220 * bg_size.scale*tem );
            caymon.y = ($(window).height() / 2) + (300*bg_size.scale*tem );
            
        }));

    };

};
if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
  $(window).ready(() => {
    $('#background').css('background-image', "url('../assets/background_no_animation.jpg')");
  });
} else {
    sf = new Phaser.Game($('#background').innerWidth(), $('#background').innerHeight(), Phaser.AUTO, 'effect', null, true);
    sf.state.add('intro', intro);
    sf.state.start('intro');
}


/***/ }),
/* 1 */
/***/ (function(module, exports) {


gallery = function() {
	var buArr = [], arlen;
	var deg = 0;
	var videos = [];
	var selected = 2;
	this.addCN = function(){
		videos = ["https://www.youtube.com/embed/HZxrv0SydBI","https://www.youtube.com/embed/75dK-PVFQUI","https://www.youtube.com/embed/LBzdlk_t-UQ","https://www.youtube.com/embed/Egpy9XJBMps","https://www.youtube.com/embed/fPyHgfsBCTM"];
		var buarr = ["Item_T2","Item_T1","Item_Center","Item_B1","Item_B2"];
		for(var i = 1; i<=buarr.length;++i){
			$("#slider_"+i).removeClass().addClass(buarr[i-1] + " pointer");
			$(".button").on('click',() =>{
				this.onclickSlider(selected);
			});
		}
		$(".close_button").on('click',()=>{
			$(".popup_gallery").fadeOut(600);
		});
	};
	rotatewaterwheel = function(a,dis){
		deg = deg + a*dis;
		$("#waterwheel").css('transform', 'rotate(' + deg + 'deg)');
	};
	this.process = function(){
		$(".pointer").each(function(){
			buArr.push($(this).attr('class'))
		});
		arlen = buArr.length;
		for (var i = 0; i < arlen; ++i) {
			buArr[i] = buArr[i].replace(" pointer","");
		};
		$(".pointer").click(function(buid) {
			var me = this,
			id = this.id||buid,
			joId=$("#" +id),
			joCN=joId.attr('class').replace(" pointer","");
			var cpos=buArr.indexOf(joCN),mpos=buArr.indexOf("Item_Center");
			selected = cpos;
			if (cpos === mpos){
				
				
			}
			if(cpos > mpos && cpos >0 && mpos >0 || cpos == 0 && mpos == 4 ||  cpos == 1 && mpos == 0)
			{
				rotatewaterwheel(1,50);
				
			}	
			if(cpos < mpos && mpos >0 && cpos >0   || mpos == 0 && cpos == 4 ||  cpos == 0 && mpos == 1)
			{
				rotatewaterwheel(-1,50);
				
			}
			if(cpos!=mpos){
				tomove = cpos > mpos?arlen-cpos+mpos:mpos-cpos;
				while(tomove){
					var t = buArr.shift();
					buArr.push(t);
					for(var i = 1;i<=arlen;++i){
						 $("#slider_"+i).removeClass().addClass(buArr[i-1]+" pointer");
					}
					--tomove;
				}
			}

		});		


	};
	this.onclickSlider = function(index){
		$("#video").attr('src', videos[index]);
		$(".popup_gallery").fadeIn(600);
		console.log(index);
	
	};
	this.run = function(){
		this.addCN();
		this.process();	
		
	};
};
module.exports = gallery;




/***/ }),
/* 2 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(0);


/***/ })
/******/ ]);