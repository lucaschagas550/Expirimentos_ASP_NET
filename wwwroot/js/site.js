// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//function validarFormulario(event, fields) {
//    event.preventDefault(); // Prevent form submission

//    var isValid = true;

//    // Iterate through the fields to be validated
//    fields.forEach(function (field) {
//        var element = document.getElementById(field.id);
//        var feedbackElement = element.nextElementSibling; // Assuming feedback element is right after the input

//        if (!element.checkValidity()) {
//            isValid = false;
//            element.classList.add('is-invalid');
//            if (feedbackElement) {
//                feedbackElement.textContent = field.errorMsg;
//                feedbackElement.classList.add('invalid-feedback'); // Ensure it has the correct class
//            }
//        } else {
//            element.classList.remove('is-invalid');
//            element.classList.add('is-valid');
//            if (feedbackElement) {
//                feedbackElement.textContent = '';
//                feedbackElement.classList.remove('invalid-feedback');
//            }
//        }

//        // Add event listener to revalidate on input
//        element.addEventListener('input', function () {
//            if (element.checkValidity()) {
//                element.classList.remove('is-invalid');
//                element.classList.add('is-valid');
//                if (feedbackElement) {
//                    feedbackElement.textContent = '';
//                    feedbackElement.classList.remove('invalid-feedback');
//                }
//            } else {
//                element.classList.remove('is-valid');
//                element.classList.add('is-invalid');
//                if (feedbackElement) {
//                    feedbackElement.textContent = field.errorMsg;
//                    feedbackElement.classList.add('invalid-feedback');
//                }
//            }
//        });
//    });

//    if (isValid) {
//        // If all fields are valid, submit the form
//        document.getElementById('formSubmit').submit();
//    } else {
//        // Otherwise, stop the form submission
//        event.stopPropagation();
//    }

//    // Add Bootstrap validation classes to the form
//    document.getElementById('formSubmit').classList.add('was-validated');
//}

function validarFormulario(event, fields) {
    event.preventDefault(); // Prevent form submission

    var isValid = true;

    // Validate all fields
    fields.forEach(function (field) {
        if (!validateField(field)) {
            isValid = false;
        }

        // Add event listener to revalidate on input
        var element = document.getElementById(field.id);
        element.addEventListener('input', function () {
            validateField(field);
        });
    });

    if (isValid) {
        // If all fields are valid, submit the form
        document.getElementById('formSubmit').submit();
    } else {
        // Otherwise, stop the form submission
        event.stopPropagation();
    }

    // Add Bootstrap validation classes to the form
    //document.getElementById('formSubmit').classList.add('was-validated');
}

// Custom validation function
function validateField(field) {
    var element = document.getElementById(field.id);
    var feedbackElement = element.nextElementSibling; // Assuming feedback element is right after the input
    var fieldIsValid = true;

    switch (field.type) {
        case 'price':
            var value = parseFloat(element.value.replace(',', '.'));
            fieldIsValid = !isNaN(value) && value > 0.01;
            break;
        case 'email':
            fieldIsValid = element.checkValidity();
            break;
        // Add other cases here for date, boolean, etc.
        default:
            fieldIsValid = element.checkValidity();
            break;
    }

    updateValidationState(element, feedbackElement, field.errorMsg, fieldIsValid);

    return fieldIsValid;
}

// Function to update the validation state of an element
function updateValidationState(element, feedbackElement, errorMsg, isValid) {
    if (isValid) {
        element.classList.remove('is-invalid');
        element.classList.add('is-valid');
        feedbackElement.textContent = '';
        feedbackElement.classList.remove('invalid-feedback');
    } else {
        element.classList.remove('is-valid');
        element.classList.add('is-invalid');
        feedbackElement.textContent = errorMsg;
        feedbackElement.classList.add('invalid-feedback');
    }
}
