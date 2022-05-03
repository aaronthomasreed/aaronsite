
let searchParams = new URLSearchParams(window.location.search);

let qInputs = document.querySelectorAll("[data-qstring]");

qInputs.forEach(input => {
    var qfield = input.dataset.qstring;
    var hasField = searchParams.has(qfield);

    // sets inputs value to correct value according to query string
    if (hasField) {
        var qvalue = searchParams.get(qfield);
        var qarray = qvalue.split(",");

        if (input.matches("select")) { input.value = qvalue; }

        if (input.matches("[type=checkbox]")) {
            if (input.matches("[data-qvalue]")) { input.checked = qarray.includes(input.dataset.qvalue); }
            else { input.checked = qvalue === 'true'; }
        }

        if (input.matches("[type=radio]")) { input.checked = input.value === qvalue; }
    }

    // add event listeners to qstring inputs (will need to test with ei after getting basics setup)
    if (input.matches("select") || input.matches("[type=checkbox]")) {
        input.addEventListener("change", () => {
            if (input.matches("select"))
                searchParams.set(qfield, input.value);

            if (input.matches("[type=checkbox]")) {
                if (input.matches("[data-qvalue]")) {
                    if (hasField) {
                        var qvalue = searchParams.get(qfield);
                        var qarray = qvalue.split(",");
                        var isChecked = input.checked;

                        if (isChecked) {
                            if (!qarray.includes(input.dataset.qvalue)) { qvalue += input.dataset.qvalue + ","; }
                        } else {
                            if (qvalue.includes(input.dataset.qvalue)) { qvalue = qvalue.replace(input.dataset.qvalue + ",", ""); }
                        }

                        searchParams.set(qfield, qvalue);
                    } else {
                        searchParams.set(qfield, input.dataset.qvalue + ",");
                    }
                }
                else { searchParams.set(qfield, input.checked); }
            }

            updateTrigger();
        });
    }

    if (input.matches("[type=radio]")) {
        input.addEventListener("click", () => {
            searchParams.set(qfield, input.value);

            updateTrigger();
        });
    }

});

let updateTrigger = function () {
    let trigger = document.getElementById("qstring-trigger");

    let returnUrl = window.location.href.split('?')[0];

    trigger.setAttribute("href", returnUrl + "?" + searchParams);
}