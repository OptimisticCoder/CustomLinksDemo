(function ($) {

    $.fn.customLinks = function () {

        return this.each(function () {

            $(this).find('.link-title').each(function () {
                $(this).click(function () {

                    var nextChild = $(this).next();

                    if ($(this).parent().parent().hasClass('custom-menu')) {
                        $(this).parent().parent().find('.sub-menu').fadeOut('slow');
                        nextChild.css('left', $(this).position().left);
                    }

                    nextChild.slideToggle('slow');
                });
            });

        });
    };

}(jQuery));