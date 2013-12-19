$(function() {

    $('.register-btn').on('click', function(e) {
        if (false == isRegisterMode()) {
            TurnOnRegister();
            e.preventDefault();
        }
    });
    $('.login-btn').on('click', function(e) {
        if (isRegisterMode()) {
            TurnOffRegister();
            e.preventDefault();
        }
    });

    $('.register-off-btn').on('click', function(e) {
        TurnOffRegister();
        e.preventDefault();
    });
    // 检测当前页面是否是注册
    if (location.search.indexOf('register') > 0 || $('#main-form').data('form-mode') === 'register')
        TurnOnRegister();
    else {
        $('.register-field').css('display', 'none');
        TurnOffRegister();
    }

    // 处理表单提交的验证
    $('[name=repeat_password]').on('keyup', function() {

        var error = false;
        var $this = $(this);
        var password = $('[name=password]').val();
        var rePassword = $this.val();

        if (false == isRegisterMode())
            return;

        if (!error && password != rePassword)
            error = "两次密码输入不同。";

        if (error)
            showError(this, error);
        else
            hideError(this);
    });
    $('[name=account]').on('keyup', function() {
        var error = false;
        var $this = $(this);
        var val = $this.val();
        //debugger
        if (!val || val.length == 0)
            error = "请输入用户名";

        if (!error && val.indexOf(' ') >= 0)
            error = "用户名不能包含空格";

        if (!error && val.length < 4)
            error = "用户名至少为 4 位";

        if (error)
            showError(this, error);
        else
            hideError(this);
    });

    $('[name=password]').on('keyup', function() {
        var error = false;
        var $this = $(this);
        var val = $this.val();

        if (!val || val.length == 0)
            error = "请输入密码";

        if (!error && val.length < 4)
            error = "密码至少为 4 位";

        // 改变密码的时候，验证确认密码
        $('[name=repeat_password]').trigger('keyup');

        if (error)
            showError(this, error);
        else
            hideError(this);
    });
    // 处理提交
    $('#main-form').submit(function(e) {
        var $this = $(this);
        var $tooltip = $this.find('.tooltip:visible');

        // 有错误提示
        if ($tooltip.size() > 0) {
            e.preventDefault();
            $tooltip.siblings('.input-group').tooltip('show');
        }
    });
});

function showError(item, error) {
    var $item = $(item).closest('.input-group');

    //$item.tooltip('hide')
    $item
        .tooltip({ title: error, placement: "auto", trigger: "manual" })
        .attr('title', error)
        .tooltip('fixTitle');

    //if($item.is(':visible'))
    $item.tooltip('show');
}

function hideError(item) {
    var $item = $(item).closest('.input-group');
    $item.tooltip('hide');
}

function isRegisterMode() {
    //return $('#main-form').data('form-mode') === 'register';
    return $('.register-field').height() > 0 && $('.register-field').is(":visible");
}

function TurnOnRegister() {
    $('#main-form').attr('action', $('#main-form').data('register-action'));
    $('.register-field').css('display', 'block').addClass("animated bounceIn"); //.slideDown();
}

function TurnOffRegister() {
    $('#main-form').attr('action', $('#main-form').data('login-action'));
    $('.register-field').slideUp();
}