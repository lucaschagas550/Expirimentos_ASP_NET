// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Funcao JS padrao do Boostrap para validar Forms, com duas melhoria, uma para nao validar campos hidden e receber o id do form como parametro assim valida 2 form na mesma tela
function validateForm(event, formId) {
    'use strict';

    const form = document.getElementById(formId);

    if (!validateControls(form)) {
        event.preventDefault();
        event.stopPropagation();
        form.classList.add('was-validated');
        return false;
    }

    addSubmitEventListener(form);
    return true;
}

function validateControls(form) {
    const controls = Array.from(form.elements).filter(element => element.type !== 'hidden');
    return controls.every(control => control.checkValidity());
}

function addSubmitEventListener(form) {
    form.addEventListener('submit', function (event) {
        if (!validateControls(form)) {
            event.preventDefault();
            event.stopPropagation();
            form.classList.add('was-validated');
        }
    }, false);
}

//Funcao JS personalizada com Boostrap para validar Forms
// Example starter JavaScript for disabling form submissions if there are invalid fields
//function validarFormulario(event, fields) {
//    event.preventDefault(); // Prevent form submission

//    var isValid = true;

//    // Validate all fields
//    fields.forEach(function (field) {
//        if (!validateField(field)) {
//            isValid = false;
//        }

//        // Add event listener to revalidate on input
//        var element = document.getElementById(field.id);
//        if (field.type === 'radio') {
//            // Add change event listener for radio buttons
//            var radioGroup = document.getElementsByName(field.name);
//            radioGroup.forEach(function (radio) {
//                radio.addEventListener('change', function () {
//                    validateField(field);
//                });
//            });
//        } else {
//            element.addEventListener('input', function () {
//                validateField(field);
//            });
//        }
//    });

//    if (isValid) {
//        // If all fields are valid, submit the form
//        document.getElementById('formSubmit').submit();
//    } else {
//        // Otherwise, stop the form submission
//        event.stopPropagation();
//    }

//    // Add Bootstrap validation classes to the form
//    //document.getElementById('formSubmit').classList.add('was-validated');
//}

//// Custom validation function
//function validateField(field) {
//    var element = document.getElementById(field.id);
//    var feedbackElement = element.nextElementSibling; // Assuming feedback element is right after the input
//    var fieldIsValid = true;

//    switch (field.type) {
//        case 'price':
//            var value = parseFloat(element.value.replace(',', '.'));
//            fieldIsValid = !isNaN(value) && value > 0.01;
//            break;
//        case 'email':
//            fieldIsValid = element.checkValidity();
//            break;
//        // Add other cases here for date, boolean, etc.
//        case 'radio':
//            fieldIsValid = document.querySelector(`input[name="${field.name}"]:checked`) !== null;
//            feedbackElement = document.querySelector(`input[name="${field.name}"]`).closest('.form-check-inline').querySelector('.invalid-feedback');
//            break;
//        default:
//            fieldIsValid = element.checkValidity();
//            break;
//    }

//    updateValidationState(element, feedbackElement, field.errorMsg, fieldIsValid);

//    return fieldIsValid;
//}

//// Function to update the validation state of an element
//function updateValidationState(element, feedbackElement, errorMsg, isValid) {
//    if (isValid) {
//        element.classList.remove('is-invalid');
//        element.classList.add('is-valid');
//        feedbackElement.textContent = '';
//        feedbackElement.classList.remove('invalid-feedback');
//    } else {
//        element.classList.remove('is-valid');
//        element.classList.add('is-invalid');
//        feedbackElement.textContent = errorMsg;
//        feedbackElement.classList.add('invalid-feedback');
//    }
//}
