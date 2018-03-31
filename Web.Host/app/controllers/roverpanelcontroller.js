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
        $('.first-step-btn').on('click', function () {
            var upperBounds = $('.upper-bound .x-axis').val().concat(" ", $('.upper-bound .y-axis').val());
            if (validationProvider.isPointValid(upperBounds)) {
                vm.state.upperBounds = upperBounds;
                $('.rover-control-panel .control-item.state').removeClass('hidden');
            }
            else {
                $('.error').removeClass('hidden');
            }
        });
        $('.second-step-btn').on('click', function () {
            var state = $('.state .x-axis').val().concat(" ", $('.state .y-axis').val()," ",$('.state .direction').val());
            if (validationProvider.isStateValid(state)) {
                vm.state.state = state;
                $('.rover-control-panel .control-item.instructions').removeClass('hidden');
            }
            else {
                $('.error').removeClass('hidden');
            }
        });
    }

    return RoverPanelController;
})((state || (state = {})) && (httpService || (httpService = {})));
