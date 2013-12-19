$(function() {
	// 将 dropdwon 当做 select
	$('.dropdown-to-select + .dropdown-menu a').on("click", function(e) {
		ActiveDropdownItem(this);
		e.preventDefault();
	});
	
	// for default-value
	$('.dropdown-to-select').each(function()
			{
				var $this = $(this);
				var val = $this.data('default-value');
				ActiveDropdownItem($this.find('+ .dropdown-menu a[data-value='+val+']'));
			});
});

/**
 * 激活 dropdown 里的项
 * 
 * @param index
 *            可选的index，不会使用，只是为了方便 each
 * @param item
 */
function ActiveDropdownItem(index, item) {
	// 如果 item 不存在，则 item 为 index
	if (!item)
		item = index;
	
	var $item = $(item);
	if($item.size() == 0)
		return;
	
	var $dropdown = $item.closest('.dropdown-menu').siblings(".dropdown-to-select");
	var name = $dropdown.data('name');
	var $field = $dropdown.siblings("input[name=" + name + "]");
	var $keep = $dropdown.find('.keep-content');

	$field.val($item.data('value'));
	$dropdown.text($item.text()).append($keep);
}

function animateHover(element, animate) {
	var $element = $(element);
	$element.hover(function() {
		$element.addClass("animate " + animate);
	}, function() {
		$element.removeClass("animate " + animate);
	});
}
function animateClick(element, animate) {
	var $element = $(element);
	$element.click(function() {
		$element.addClass("animated " + animate);
	}).one('webkitAnimationEnd mozAnimationEnd oAnimationEnd animationEnd',function() {
				$element.removeClass("animate " + animate);
			});
	
}
function animateShow(element, animate) {
	var $element = $(element);
	$element.hover(function() {
		$element.addClass("animated " + animate);
	}, function() {
		$element.removeClass("animate " + animate);
	});
}