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
        this.showError = showError;
    }
    function isPointValid(val) {
        var isValid = val.match(/^\d\s\d$/);
        showError(isValid,"upperbound");
        return isValid;
    }
    function isStateValid(val) {
        var isValid = val.match(/^\d\s\d\s[nwseNWSE]$/);
        showError(isValid,"states");
        return isValid;
    }
    function isInstractionValid(val) {
        var isValid = val.match(/^[lrmLRM]{1,}$/);
        showError(isValid,"instructions");
        return isValid;
    }
    function showError(isValid,type) {
        if (isValid) {
            $('.error.'+type).addClass('hidden');
        }
        else {
            $('.error.'+type).removeClass('hidden');
        }
    }
    if (!validationProviderInstance)
        validationProviderInstance = new ValidationProvider();
    return validationProviderInstance;
})();