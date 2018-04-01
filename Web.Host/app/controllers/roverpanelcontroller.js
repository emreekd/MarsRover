var httpService;
var state;

/**
 * Controller for Rover Management Page
**/
var RoverPanelController = (function (state, httpService) {
    'use strict';
    function RoverPanelController(state, httpService, validationProvider) {
        var vm = this;
        vm.httpService = httpService;
        vm.validationProvider = validationProvider;
        vm.state = state = {};
        /*
        * Get upper bounds and set it on state
        */
        $('.first-step-btn').on('click', function () {
            var upperBounds = $('.upper-bound .x-axis').val().concat(" ", $('.upper-bound .y-axis').val());
            if (validationProvider.isPointValid(upperBounds)) {
                $(this).attr('disabled', 'disabled');
                $(this).val("Locked");
                vm.state.upperBounds = { X: $('.upper-bound .x-axis').val(), Y: $('.upper-bound .y-axis').val() };
                $('.rover-control-panel .control-item.state').removeClass('hidden');
            }
        });
        /*
        * Get initial state of each rover and keep rovers on state
        */
        $('.second-step-btn').on('click', function () {
            var rovers = [];
            $('.state .x-axis').each(function (index) {
                if (!rovers[$(this).data('rovercode') - 1]) {
                    rovers[$(this).data('rovercode') - 1] = {};
                }
                rovers[$(this).data('rovercode') - 1].X = $(this).val();
            });
            $('.state .y-axis').each(function (index) {
                if (!rovers[$(this).data('rovercode') - 1]) {
                    rovers[$(this).data('rovercode') - 1] = {};
                }
                rovers[$(this).data('rovercode') - 1].Y = $(this).val();
            });
            $('.state .direction').each(function (index) {
                if (!rovers[$(this).data('rovercode') - 1]) {
                    rovers[$(this).data('rovercode') - 1] = {};
                }
                rovers[$(this).data('rovercode') - 1].Direction = $(this).val();
            });
            // check whether states are valid and manage error
            var statesValid = true;
            for (var i = 0; i < rovers.length; i++) {
                if (rovers[i].X >= 0 && rovers[i].X <= vm.state.upperBounds.X
                    && rovers[i].Y >= 0 && rovers[i].Y <= vm.state.upperBounds.Y) {
                    if (!validationProvider.isStateValid(rovers[i].X + " " + rovers[i].Y + " " + rovers[i].Direction)) {
                        statesValid = false;
                        break;
                    }
                }
                else {
                    statesValid = false;
                    validationProvider.showError(false, "states");
                    break;
                }
            }
            if (statesValid) {
                $(this).attr('disabled', 'disabled');
                $(this).val("Locked");
                vm.state.Rovers = rovers;
                $('.rover-control-panel .control-item.instructions').removeClass('hidden');
            }
        });
        /*
        * Get instruction for each rover and send that instructions to server and process
        */
        $('.third-step-btn').on('click', function () {
            var instructions = [];
            var isInsValid = true;
            $('.instructions .instruction').each(function (index) {
                var instruction = $(this).val();
                vm.state.Rovers[$(this).data('rovercode') - 1].Instruction = $(this).val();

            });
            for (var i = 0; i < vm.state.Rovers.length; i++) {
                if (!validationProvider.isInstractionValid(vm.state.Rovers[i].Instruction)) {
                    isInsValid = false;
                    break;
                }
            }
            //process to result if instruction valid
            if (isInsValid) {
                $(this).attr('disabled', 'disabled');
                $(this).val("Locked");
                httpService.post("Default/SendInstructions", { UpperBounds: vm.state.upperBounds, Rovers: vm.state.Rovers }, null, function (response) {
                    if (response && response.length > 0) {
                        var panel = $('.control-item.result');
                        panel.removeClass('hidden');
                        $('html, body').animate({
                            scrollTop: panel.offset().top
                        }, 2000);
                        for (var i = 0; i < response.length; i++) {
                            var result = "<p>Rover" + (i + 1) + " Position: " + response[i].X + " " + response[i].Y + " " + response[i].Direction + "</p>";
                            panel.append(result);
                        }
                    }
                });
            }
        });
    }

    return RoverPanelController;
})((state || (state = {})) && (httpService || (httpService = {})));
