(function() {
})()

function RequiredValidator(element) {
    console.log(typeof(element));
    switch(typeof(element)) {
        case 'text':
            return !!(element && element.value);
        case 'password':
            return !!(element && element.value);
        case 'checkbox':
            return !!(element && element.checked);
    }
}    

RequiredValidator.errorText = " - is required";

function RegExpValidator(element, regexp) {
    //return !element || !element.value || regexp.match(element.value);

    console.log("element.value " + element.value);
    console.log("regexp " + regexp);
        
    /*let www = document.getElementById("password").value.match(numbers);

    console.log("www " + www);
    console.log("element.value.match(numbers) " + element.value.match(numbers));*/

    console.log("element.value.match(regexp)" + element.value.match(regexp));

    let numbers = /[0-9]/g;
    return element.value.match(regexp);
}
class FieldValidator {
    static Required = RequiredValidator;

    static RegExp(regexp) {
        let validate = (elem) => RegExpValidator(elem, regexp);
        validate.errorText = "should be " + regexp;
        return validate ;
    }

    constructor(id, validators) {
        this._id = id;
        this._validators = validators;
        this._isValid = true;
    }

    initialize() {
        this._element = document.getElementById(this._id);
        let wrapper = document.createElement("span");
        this._element.replaceWith(wrapper);
        wrapper.appendChild(this._element);
    }

    validate() {
        if (this._validators) {
            this._isValid = true;
            this._validators.forEach(validate => {
                if (!validate(this._element)) {
                    this._showError(this._element.name + validate.errorText);
                    this._isValid = false;
                }
            });
        }
    }

    isValid() {
        return this._isValid;
    }

    _showError(error) {
        this._clearErrors();
        let errorElem = document.createElement("span");
        errorElem.className = "error";
        errorElem.innerText = error;
        this._element.parentElement.appendChild(errorElem);
    }

    _clearErrors() {
        for (const elem of this._element.parentElement.children) {
            if (elem.className == 'error') {
                elem.remove();
            }
        }
    }
}