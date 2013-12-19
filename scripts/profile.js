$(function(){
	$.fn.editable.defaults.mode = "inline";
	$.fn.editable.defaults.ajaxOptions = {type: "post"};
	$.fn.editable.defaults.emptytext = "暂无";
	
	$('.editable')
		.editable()
		
	;
	$('[data-name=qq]').editable('option', 'validate', function(v) {
	    if(! /[0-9]{5,13}/.test(v)) return 'QQ 号格式错误';
	});
	

	
	// 重置按钮
	$('.reset-btn').click(function() {
	    $('.editable').editable('setValue', null)  //clear values
	        .editable('option', 'pk', null)          //clear pk
	        .removeClass('editable-unsaved');        //remove bold css
	                   
             
	});
	// 保存
	$('.submit-btn').click(function() {
		   $('.editable').editable('submit', { 
			   url:"edit_profile.jsp",
		       ajaxOptions: {
		           dataType: 'json' //assuming json response
		       },
		       success: function(data, config) {
		    	   //debugger;
		           if(data && data.suc) {
		               //set pk
		               //$(this).editable('option', 'pk', data.id);
		               //remove unsaved class
		               $(this).removeClass('editable-unsaved');
		               //show messages
		               var msg = 'New user created! Now editables submit individually.';
		               //$('#msg').addClass('alert-success').removeClass('alert-error').html(msg).show();
		               //$('.submit-btn').hide(); 
		               //$(this).off('save.newuser');                     
		           } else if(data && data.error){ 
		               //server-side validation error, response like {"errors": {"username": "username already exist"} }
		               config.error.call(this, data.error);
		           }               
		       },
		       error: function(errors) {
		           var msg = '';
		           if(errors && errors.responseText) { //ajax error, errors = xhr object
		               msg = errors.responseText;
		           } else if($.type(errors) == "string")
		           {
		        	   msg = errors;
		           }else{ //validation error (client-side or server-side)
		               $.each(errors, function(k, v) { msg += k+": "+v+"<br>"; });
		           } 
		           $('#msg').removeClass('alert-success')
		           	.addClass('alert-error')
		           	.find('#msg-text').html(msg).end()
		           	.removeClass('hide')
		           	.show()
		           	;
		       }
		   });
		});
	
});