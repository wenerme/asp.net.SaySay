$(function()
{
	// 处理表单提交的验证
	$('[name=repeat_password]').on('keyup',function()
	{
		
		var error = false;
		var $this = $(this);
		var password = $('[name=password]').val();
		var rePassword = $this.val();
		
		if(!error && password != rePassword)
			error = "两次密码输入不同。";
		
		if(error)
			showError(this, error);
		else
			hideError(this);
	});
	
	$('[name=old_password],[name=password]').on('keyup',function()
			{
				var error = false;
				var $this = $(this);
				var val = $this.val();
				
				if(!val || val.length == 0)
					error = "请输入密码";
				
				if(!error && val.length < 4)
					error = "密码至少为 4 位";
				
				// 改变密码的时候，验证确认密码
				$('[name=repeat_password]').trigger('keyup');
				
				if(error)
					showError(this, error);
				else
					hideError(this);
			});
	// 处理提交
	$('#main-form').submit(function(e)
		{
			var $this = $(this);
			var $tooltip = $this.find('.tooltip:visible');
			
			// 有错误提示
			if($tooltip.size() > 0)
			{
				e.preventDefault();
				$tooltip.siblings('.input-group').tooltip('show');
			}
		});
});
function showError(item, error)
{
	var $item = $(item).closest('.input-group');
	
	//$item.tooltip('hide')
	$item
	.tooltip({title: error,placement:"auto",trigger:"manual"})
	.attr('title', error)
	.tooltip('fixTitle');
	
	//if($item.is(':visible'))
	$item.tooltip('show');
}
function hideError(item)
{
	var $item = $(item).closest('.input-group');
	$item.tooltip('hide');
}