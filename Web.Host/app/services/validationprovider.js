var validationProviderInstance;
/**
 * A wrapper for control page validators
 * to allow or restrict ui actions
**/
var ValidationProvider = (function () {
    function ValidationProvider() {
        this.isPointValid = isPointValid;
        this.isStateValid = isStateValid;
        this.isInstractionValid = isInstractionValid;
    }
    function isPointValid(val) {
        var isValid = val.match(/^\d\s\d$/);
        showError(isValid);
        return isValid;
    }
    function isStateValid(val) {
        var isValid = val.match(/^\d\s\d\s[nwseNWSE]$/);
        showError(isValid);
        return isValid;
    }
    function isInstractionValid(val) {
        var isValid = val.match(/^[lrmLRM]{1,}$/);
        showError(isValid);
        return isValid;
    }
    function showError(isValid) {
        if (isValid) {
            $('.error').addClass('hidden');
        }
        else {
            $('.error').removeClass('hidden');
        }
    }
    if (!validationProviderInstance)
        validationProviderInstance = new ValidationProvider();
    return validationProviderInstance;
})();