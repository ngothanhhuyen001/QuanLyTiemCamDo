
$(function () {
    var isSearching = false;
    var arrSelected = [];
    var arrAvailableOrExclude = [];
    var primarySupplyLocation = '';

    //Color hex code text of each step (Step 1 -> Step 10)
    const iconColors = [
        "#29aaee",
        "#f8a4b4", //step 2
        "#ffec6c",
        "#10ac54", //step 4 
    ];

    const stepNameList = [
        "_ThietLapKhoanVay", //Step 1
        "_ThongTinKH", //Step 2
        "_HoanTat", //Step 3
    ];


    // Prevent event Enter input LoadPage
    var defaultAction = {
        init: function () {
            $(document).on("keydown", "form", function (event) {
                return event.key != "Enter";
            });
        }
    };

    // Events in DataLoad Feature
    // Have 3 status Class: 'Current', "Selected", "Completed";
    var actionStep = {
        init: function () {
            this.clickNextButton();
            this.clickPrevButton();
            this.clickCancelButton();
            //this.clickDot()
        },

        //---------------------------------------Next Button---------------------------------------------------------
        clickNextButton: function () {

            //$('.modal-body .next-button #').on('click', function () {
            $('#btnNext').on('click', function () {
                var inValid = true;
                var data = []; //data
                //var newContentValue = $('.step-content-container input').val(); //content Input
                var currentStepNumber = $('.modal-steps .current').attr('data-step'); // Step index ...(number)
                var selected = $('.modal-steps').find('.step.selected')  // selected Step
                var selectedStepNumber = $(selected).attr('data-step')  // Step index? ...(name)

                if (selected.length > 0) {
                    //steps completed but user want to check infor again
                    currentStepName = stepNameList[parseInt(selectedStepNumber) - 1];
                }
                else {
                    //straight forward through 12 step
                    currentStepName = stepNameList[parseInt(currentStepNumber) - 1];
                }

                var url = `/CamDoOnline/${currentStepName}`; // url to controller

                //validate input
                if (currentStepName === "_ThietLapKhoanVay") {
                    inValid = true;
                }
                else if (currentStepName === "_ThongTinKH") {
                    inValid = true;
                }
                else if (currentStepName === "_HoanTat") {
                    $("#btnNext").prop('disabled', true);
                }

                if (inValid) {
                    $("#btnNext").prop('disabled', true);
                    $("#btnPrev").prop('disabled', true);

                    $('.progress-each-step').css('visibility', 'visible');
                    $('.progress-bar-for-step').animate(
                        { width: '45%' },
                        { duration: 250 });

                    //Change status class
                    if (selected.length > 0) {
                        // trường hợp đã có Select Step
                        var selectedStepNumber = $(selected).attr('data-step'); // step number of selected

                        if (parseInt(selectedStepNumber) == parseInt(currentStepNumber) - 1) {
                            // selected trùng với step đang thực hiện cuối cùng
                            $(selected).removeClass('selected');
                        }
                        else {
                            $(selected).removeClass('selected');
                            $(selected).next().addClass('selected')
                        }

                        var selectedStepNameCurrent = stepNameList[parseInt(selectedStepNumber) - 1];
                        url = `/CamDoOnline/${selectedStepNameCurrent}`; //change url to controller
                    }

                    //Show prev Button
                    if (currentStepNumber === "1" || selectedStepNumber === "1") { // check status step 1
                        $('.modal-body .prev-button').removeClass('d-none');
                    }

                    //Hide next Button & back Button từ step 3
                    if (currentStepNumber === "3" || selectedStepNumber === "3") {
                        $('.modal-body .next-button').addClass('d-none');
                        $('.modal-body .prev-button').addClass('d-none');
                    }

                    if (currentStepNumber === "3" || selectedStepNumber === "3") {
                        $('#btnCancel').children(".text").text("Close");
                    }

                    // Call Ajax
                    $.ajax({
                        type: "POST",
                        url: url,
                        data: { data: JSON.stringify(data), buttonType: "next", stepName: currentStepName },
                        success: function (res) {

                            $("#btnNext").prop('disabled', false);
                            $("#btnPrev").prop('disabled', false);

                            $('.progress-bar-for-step').animate(
                                { width: '100%' },
                                {
                                    duration: 250, complete: function () {
                                        $('.progress-each-step').css('visibility', 'hidden');
                                        $('.progress-bar-for-step').animate({ width: '0%' });
                                    }
                                });

                            if (res === "Fail") {
                                return;
                            }

                            //Render PartialView
                            $('.step-content-container').html("");
                            $('.step-content-container').html(res);


                            //nếu có Selected thì Out
                            if (selected.length > 0) return false;

                            // change css "current Step" to "Completed"
                            var current = $('.modal-steps .current');
                            $(current).removeClass('current').addClass('completed');

                            setTimeout(function () {

                                //change status 'Step' in normal case
                                if (parseInt(currentStepNumber) < 3) {
                                    $(current).next().addClass('current');//change status class
                                }

                                //change color text of next step
                                var colorIndex = parseInt(currentStepNumber); //get color Index in color code list
                                $(current).next().children('label[data-type="text"]').css('color', `${iconColors[colorIndex]}`);

                                //change color dot of next step in normal case
                                $(current).children('.dot').css('--completed', `${iconColors[colorIndex - 1]}`); //get color Index in color code list
                                $(current).children('.dot').css('background-color', `${iconColors[colorIndex - 1]}`);

                                //change status 'Step' and change dot color in step 4 case
                                if (parseInt(currentStepNumber) === 3) {
                                    $('.modal-steps .step:nth-child(3)').addClass('completed');
                                    $('.modal-steps .step:nth-child(3)').children('.dot').css('--completed', `${iconColors[3]}`);
                                    $('.modal-steps .step:nth-child(3)').children('.dot').css('background-color', `${iconColors[3]}`);
                                }

                                //disable dot step 1 - step 3 in step 4 case
                                if (parseInt(currentStepNumber) === 3) {
                                    $(".step[data-step='1'] .dot").prop('disabled', true);
                                    $(".step[data-step='2'] .dot").prop('disabled', true);
                                    $(".step[data-step='3'] .dot").prop('disabled', true);
                           
                                    //hide prev button
                                    $('.modal-body .buttons .prev-button').addClass('d-none');
                                }

                                ////change icon
                                //var oldSrcImage = $(current).next().find('img').attr('src'); //current src
                                //oldSrcImage = oldSrcImage.slice(0, oldSrcImage.length - 4) // cắt đuôi file

                                //var newSrcImage = `${oldSrcImage}-color.png`; // change new file name
                                //$(current).next().find('img').attr('src', newSrcImage) // change new src                   

                                ////Show prev button
                                $('.modal-body .buttons .prev-button').removeClass('d-none');

                            }, 150)
                        },
                        error: function () {
                            aler("Processing data failed. Please try again.");
                            console.log('Error')
                        }
                    });
                    arrSelected = [];
                    arrAvailableOrExclude = [];
                }
            })
        },

        //---------------------------------------Prev Button---------------------------------------------------------
        clickPrevButton: function () {
            $('#btnPrev').on('click', function () {
                //Get element && step number
                var current = $('.modal-steps .current');
                var currentStepNumber = $(current).attr('data-step');
                var selected = $('.modal-steps').find('.step.selected');
                var selectedStepNumber = $(selected).attr('data-step');
                var actionName = stepNameList[parseInt(currentStepNumber) - 1];

                //change url khi co selected
                if (selected.length > 0) {
                    actionName = stepNameList[parseInt(selectedStepNumber) - 1];
                }

                //set url
                var url = `/CamDoOnline/${actionName}`; // url to controller

                if ($("#btnNext").attr('disabled')) {
                    $("#btnNext").show();
                    $("#btnNext").prop('disabled', false);
                }

                //change Status Class
                if (selected.length > 0) {
                    //Đã có Selected
                    $(selected).removeClass('selected');  // remove old selected
                    $(selected).prev().addClass('selected'); // set new selected
                } else {
                    $(selected).removeClass('selected');  // remove old selected
                    $(current).prev().addClass('selected'); // set new selected
                }

                //Hide prev button
                if (selectedStepNumber === "1" || currentStepNumber === "1") {
                    $('.modal-body .prev-button').addClass('d-none');
                }

                //Hide prev button
                if (selectedStepNumber === "4" || currentStepNumber === "4") {
                    $('.modal-body .prev-button').addClass('d-none');
                }

                //Show next Button
                if (parseInt(currentStepNumber) <= 3) {
                    $('.modal-body .next-button').removeClass('d-none');
                }

                $.ajax({
                    type: "POST",
                    url: url,
                    data: { data: '', buttonType: 'prev', stepName: actionName },
                    success: function (res) {

                        if (res === "Fail") return;

                        //Render PartialView
                        $('.step-content-container').html("");
                        $('.step-content-container').html(res);
                    },
                    error: function () {
                        console.log('error');
                    }
                });
            })
        },

        //---------------------------------------Cancel Button-------------------------------------------------------
        clickCancelButton: function () {
            $('#btnCancel').on('click', function () {
                $('#exampleModal').modal('show')
            });
        }
    };

    defaultAction.init();
    actionStep.init();


});


