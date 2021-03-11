﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function InternLeave(iid, btn) {

    $.ajax({
        method: "POST",
        url: "Home/InternLeave",
        data: { id: iid }
    }).done(function (msg) {
        alert("Gone: " + msg);

        var row = btn.parentNode.parentNode;
        row.parentNode.remove();
    });
}


$(document).on('ready', function () {

    // INITIALIZATION OF MEGA MENU
    // =======================================================
    var megaMenu = new HSMegaMenu($('.js-mega-menu'), {
        desktop: {
            position: 'left'
        }
    }).init();



    // INITIALIZATION OF NAVBAR VERTICAL NAVIGATION
    // =======================================================
    var sidebar = $('.js-navbar-vertical-aside').hsSideNav();


    // INITIALIZATION OF TOOLTIP IN NAVBAR VERTICAL MENU
    // =======================================================
    $('.js-nav-tooltip-link').tooltip({ boundary: 'window' })

    $(".js-nav-tooltip-link").on("show.bs.tooltip", function (e) {
        if (!$("body").hasClass("navbar-vertical-aside-mini-mode")) {
            return false;
        }
    });


    // INITIALIZATION OF UNFOLD
    // =======================================================
    $('.js-hs-unfold-invoker').each(function () {
        var unfold = new HSUnfold($(this)).init();
    });


    // INITIALIZATION OF FORM SEARCH
    // =======================================================
    $('.js-form-search').each(function () {
        new HSFormSearch($(this)).init()
    });


    // INITIALIZATION OF SHOW PASSWORD
    // =======================================================
    $('.js-toggle-password').each(function () {
        new HSTogglePassword(this).init()
    });


    // INITIALIZATION OF FILE ATTACH
    // =======================================================
    $('.js-file-attach').each(function () {
        var customFile = new HSFileAttach($(this)).init();
    });


    // INITIALIZATION OF TABS
    // =======================================================
    $('.js-tabs-to-dropdown').each(function () {
        var transformTabsToBtn = new HSTransformTabsToBtn($(this)).init();
    });


    // INITIALIZATION OF MASKED INPUT
    // =======================================================
    $('.js-masked-input').each(function () {
        var mask = $.HSCore.components.HSMask.init($(this));
    });


    // INITIALIZATION OF SELECT2
    // =======================================================
    $('.js-select2-custom').each(function () {
        var select2 = $.HSCore.components.HSSelect2.init($(this));
    });


    // INITIALIZATION OF COUNTERS
    // =======================================================
    $('.js-counter').each(function () {
        var counter = new HSCounter($(this)).init();
    });


    // DARK POPOVER
    // =======================================================
    $('[data-toggle="popover-dark"]').on('shown.bs.popover', function () {
        $('.popover').last().addClass('popover-dark')
    });




    // INITIALIZATION OF TAGIFY
    // =======================================================
    $('.js-tagify').each(function () {
        var tagify = $.HSCore.components.HSTagify.init($(this));
    });

    var gestsField = null

    function getAvatar(tagData) {
        if (tagData.src.length) {
            return "<img class=\"avatar avatar-xs avatar-circle mr-2\" src=\"" + tagData.src.toLowerCase() + "\">"
        } else {
            return "<span class=\"avatar avatar-xs avatar-soft-primary avatar-xs avatar-circle mr-2\">" +
                "<span class=\"avatar-initials\">" + tagData.value.charAt(0) + "</span>" +
                "</span>"
        }
    }

    $('#eventGestsLabel').each(function () {
        var settings = $(this).attr('data-hs-tagify-options') ? JSON.parse($(this).attr('data-hs-tagify-options')) : {}

        gestsField = $.HSCore.components.HSTagify.init($(this), {
            templates: {
                tag: function tag(tagData) {
                    try {
                        return "<tag title=\"" + tagData.value + "\" contenteditable=\"false\" spellcheck=\"false\" class=\"tagify__tag " + (tagData["class"] ? tagData["class"] : "") + "\" " + this.getAttributes(tagData) + ">" +
                            "<x title=\"remove tag\" class=\"tagify__tag__removeBtn\"></x>" +
                            "<div class=\"d-flex align-items-center\">" +
                            getAvatar(tagData) +
                            "<span>" + tagData.value + "</span>" +
                            "</div>" +
                            "</tag>";
                    } catch (err) { }
                },
                dropdownItem: function dropdownItem(tagData) {
                    try {
                        return "<div " + this.getAttributes(tagData) + " class=\"tagify__dropdown__item " + (tagData["class"] ? tagData["class"] : "") + "\">" +
                            getAvatar(tagData) +
                            "<span>" + tagData.value + "</span>" +
                            "</div>";
                    } catch (err) { }
                }
            }
        })

        gestsField.addTags(settings.whitelist.slice(0, 0));
    });


    // INITIALIZATION OF FULLCALENDAR SELECT2
    // =======================================================
    $('.js-select2-custom').each(function () {
        var select2 = $.HSCore.components.HSSelect2.init($(this));
    });


    // INITIALIZATION OF FLATPICKR
    // =======================================================
    const eventDateRange = $.HSCore.components.HSFlatpickr.init($('#eventDateRangeLabel'));


    // INITIALIZATION OF FULLCALENDAR
    // =======================================================
    const prevMonthBtn = $('[data-fc-prev-month]')
    const nextMonthBtn = $('[data-fc-next-month]')
    const todayBtn = $('[data-fc-today]')
    const dateTitle = $('[data-fc-title]')
    const gridViewSelect = $('[data-fc-grid-view]')


    const titleField = $('#eventTitleLabel')
    const repeatField = $('#eventRepeatLabel')
    const eventDescriptionLabel = $('#eventDescriptionLabel')
    const eventLocationLabel = $('#eventLocationLabel')
    const eventColorLabel = $('#eventColorLabel')
    var editableEvent = {}

    var fullcalendarEditable = $.HSCore.components.HSFullcalendar.init($('#js-fullcalendar'), {
        initialDate: "2020-12-03",
        headerToolbar: false,
        editable: true,
        defaultAllDay: false,
        datesSet(dateSet) {
            dateTitle.text(dateSet.view.title)
            console.log(1)
        },
        select: function (date) {
            prepareData('', date.startStr, date.endStr)
        },
        eventClick: function (event) {
            $('.popover').popover('dispose')

            // Get Avatars HTML
            function getAvatars(members) {
                const wrapper = $('<ul>').addClass('list-unstyled mb-0')

                members.forEach(function (member) {
                    wrapper.append(`
                  <li class="d-flex align-items-center mb-2">
                    ${getAvatar(member)}
                    <span>${member.value}</span>
                  </li>
                `)
                })

                return members.length > 0 ? wrapper[0].outerHTML : false
            }

            // Popover Content
            const content = `
              <h3 class="mb-4">${event.event.title}</h3>

              <div class="media mb-4">
                <i class="tio-time nav-icon"></i>
                <div class="media-body">
                  <span class="d-block text-dark mb-2">${moment(event.event.start).format('dddd, MMMM DD')} - ${moment(event.event.end).format('dddd, MMMM DD')}</span>
                  <span class="d-block">Repeat: <span class="text-dark text-capitalize">${event.event.extendedProps.repeatField}</span></span>
                </div>
              </div>

              <div class="media mb-4">
                <i class="tio-group-senior nav-icon"></i>
                <div class="media-body">
                  <span class="d-block text-dark">${getAvatars(event.event.extendedProps.gestsField) || 'Empty'}</span>
                </div>
              </div>

              <div class="media mb-4">
                <i class="tio-poi nav-icon"></i>
                <div class="media-body">
                  <span class="d-block text-dark">${event.event.extendedProps.eventLocationLabel || 'Empty'}</span>
                </div>
              </div>

              <div class="media mb-4">
                <i class="tio-text-left nav-icon"></i>
                <div class="media-body">
                  <span class="d-block text-dark">${event.event.extendedProps.eventDescriptionLabel || 'Empty'}</span>
                </div>
              </div>

              <div class="d-flex align-items-center mb-4">
                <div class="avatar avatar-xs avatar-circle mr-2">
                  <img class="avatar-img" src="../img/img6.jpg" alt="Image Description">
                </div>
                <div class="media-body">
                  <span class="d-block text-dark">Mark Williams</span>
                </div>
              </div>

              <div class="d-flex justify-content-end">
                <a id="closePopover" href="javascript:;" class="btn btn-sm btn-white mr-2">Close</a>
                <a id="modal-invoker-${event.event.id}" href="javascript:;" class="btn btn-sm btn-primary">
                  <i class="tio-edit"></i>
                  Edit
                </a>
              </div>
            `

            // Open Popover
            $(event.el).popover({
                html: true,
                content: content,
                template: '<div class="popover fullcalendar-event-popover" role="tooltip"><div class="arrow"></div><h3 class="popover-header"></h3><div class="popover-body"></div></div>'
            })
                .popover('show')

            // Open Popover For Editing
            $(event.el).on('shown.bs.popover', function () {
                $('#modal-invoker-' + event.event.id).click(function () {
                    $(event.el).popover('dispose')
                    prepareData(event.event.title, event.event.start, event.event.end, event.event)
                })
            })
        },
        eventContent({ event }) {
            return {
                html: `
                <div>
                  <div class="fc-event-time">${gridViewSelect.val() === 'timeGridWeek' && !event.allDay ? moment(event.start).format('HH:mm') + '-' + moment(event.end).format('HH:mm') : ''}</div>
                  <div class='d-flex align-items-center'>
                    ${event.extendedProps.image ? `<img class="avatar avatar-xs mr-2" src="${event.extendedProps.image}" alt="Image Description">` : ''}
                    <span class="fc-event-title fc-sticky">${event.title}</span>
                  </div>
                </div>
                `
            }
        },
        drop({ draggedEl }) {
            $(draggedEl).remove()
        },
        events: [
            {
                id: 1,
                title: "English Lesson",
                start: "2020-12-03",
                end: "2020-12-03",
                className: "fullcalendar-custom-event-hs-team",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "weekdays",
                allDay: true,
                gestsField: [
                    {
                        "value": "David Harrison",
                        "src": "../img/img3.jpg"
                    }
                ]
            },
            {
                id: 2,
                title: "Spanish Lesson",
                start: "2020-12-03",
                end: "2020-12-03",
                className: "fullcalendar-custom-event-hs-team",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "everyday",
                allDay: true,
                gestsField: [
                    {
                        "value": "Anne Richard",
                        "src": ""
                    },
                    {
                        "value": "Finch Hoot",
                        "src": "../img/img5.jpg"
                    }
                ]
            },
            {
                id: 3,
                title: "Monthly presentation (in PowerPoint)",
                start: "2020-12-03 04:00",
                end: "2020-12-03 05:00",
                className: "fullcalendar-custom-event-reminders",
                eventDescriptionLabel: "",
                eventLocationLabel: "Online",
                repeatField: "everyday",
                gestsField: [],
                image: '../img/atlassian.svg'
            },
            {
                id: 4,
                title: "Complete Figma course: Go from zero to hero in Figma",
                start: "2020-12-06 02:00",
                end: "2020-12-08 15:00",
                className: "fullcalendar-custom-event-hs-team",
                eventDescriptionLabel: "Learn Figma like a Professional! Start from the basics and go all the way to creating your own design!",
                eventLocationLabel: "Online",
                repeatField: "never",
                gestsField: [
                    {
                        "value": "Bob Dean",
                        "src": ""
                    },
                    {
                        "value": "Ella Lauda",
                        "src": "../img/img9.jpg"
                    },
                    {
                        "value": "Lori Hunter",
                        "src": ""
                    },
                    {
                        "value": "Costa Quinn",
                        "src": "../img/img6.jpg"
                    }
                ],
                image: '../img/atlassian.svg'
            },
            {
                id: 5,
                title: "Independence day",
                start: "2020-12-01",
                end: "2020-12-02",
                className: "fullcalendar-custom-event-holidays",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "never",
                gestsField: [],
                image: ''
            },
            {
                id: 6,
                title: "Teachers day",
                start: "2020-12-01",
                end: "2020-12-02",
                className: "fullcalendar-custom-event-holidays",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "never",
                gestsField: [],
                image: ''
            },
            {
                id: 7,
                title: "Send weekly invoice to John",
                start: "2020-12-10",
                end: "2020-12-11",
                className: "fullcalendar-custom-event-hs-team",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "everyday",
                allDay: true,
                gestsField: [
                    {
                        "value": "Linda Bates",
                        "src": "../img/img8.jpg"
                    },
                    {
                        "value": "Rachel Doe",
                        "src": ""
                    }
                ],
                image: '../img/atlassian.svg'
            },
            {
                id: 8,
                title: "Shoot a message to Christina on Slack",
                start: "2020-12-18",
                end: "2020-12-20",
                className: "fullcalendar-custom-event-tasks",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "everyday",
                gestsField: [
                    {
                        "value": "Brian Halligan",
                        "src": ""
                    }
                ],
                image: '../img/atlassian.svg'
            },
            {
                id: 9,
                title: "Open a calendar task on Jira",
                start: "2020-12-03 00:00",
                end: "2020-12-03 04:00",
                className: "fullcalendar-custom-event-hs-team",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "never",
                gestsField: [
                    {
                        "value": "Clarice Boone",
                        "src": "../img/img7.jpg"
                    },
                    {
                        "value": "Sam Kart",
                        "src": "../img/img4.jpg"
                    },
                    {
                        "value": "Mark Williams",
                        "src": "../img/img6.jpg"
                    }
                ],
                image: '../img/atlassian.svg'
            },
            {
                id: 10,
                title: "Weekly presentation (in PowerPoint)",
                start: "2020-12-14",
                end: "2020-12-17",
                className: "fullcalendar-custom-event-reminders",
                eventDescriptionLabel: "",
                eventLocationLabel: "Online",
                repeatField: "everyday",
                gestsField: [],
                image: '../img/atlassian.svg'
            },
            {
                id: 11,
                title: "Launch",
                start: "2020-12-03 01:00",
                end: "2020-12-03 02:00",
                className: "fullcalendar-custom-event-hs-team",
                eventDescriptionLabel: "",
                eventLocationLabel: "",
                repeatField: "everyday",
                gestsField: []
            },
            {
                id: 12,
                title: "Make monthly payments via MasterCard",
                start: "2020-12-11",
                end: "2020-12-12",
                className: "fullcalendar-custom-event-tasks",
                eventDescriptionLabel: "",
                eventLocationLabel: "Online",
                repeatField: "everyday",
                gestsField: [],
                image: '../img/atlassian.svg'
            }
        ]
    })

    // Events
    $('body').on('click', '#closePopover', function () {
        $('.popover').popover('dispose')
    })

    prevMonthBtn.click(function () {
        fullcalendarEditable.prev()
        $('[data-toggle="tooltip"]').tooltip('hide');
    })

    nextMonthBtn.click(function () {
        fullcalendarEditable.next()
        $('[data-toggle="tooltip"]').tooltip('hide');
    })

    todayBtn.click(function () {
        fullcalendarEditable.today()
    })

    gridViewSelect.on('change', function (event) {
        fullcalendarEditable.changeView($(event.target).val())
    })

    todayBtn.attr('title', new Date().toDateString())

    $('body').on('click', function (e) {
        if (!$(e.target).closest('.fc-event').length
            && !$(e.target).closest('.popover').length) {
            $('.popover').popover('dispose');
        }
    });

    $('#addEventToCalendarModal').on('hide.bs.modal', function () {
        titleField.css({
            height: 'auto'
        })
    })

    $('#addEventToCalendarModal').on('show.bs.modal', function () {
        clearForm()
    })

    $('#addEventToCalendarModal').on('shown.bs.modal', function () {
        titleField.css({
            height: titleField[0].scrollHeight + "px"
        })

        titleField.focus()
    })

    $(document).scroll(function () {
        if ($('.fc-more-popover').length) {
            $('.fc-more-popover').remove()
        }
    })

    titleField.on('input', function () {
        $(this).css({
            height: this.scrollHeight + "px"
        })
    })

    // Add/Edit Event
    $('#processEvent').click(function () {
        if (!Object.keys(editableEvent).length) {
            const date = eventDateRange.selectedDates

            fullcalendarEditable.addEvent({
                id: new Date().getTime(),
                title: titleField.val() || '(No title)',
                repeatField: repeatField.val(),
                gestsField: gestsField.value,
                eventDescriptionLabel: eventDescriptionLabel.val(),
                eventLocationLabel: eventLocationLabel.val(),
                start: moment(date[0]).format('YYYY-MM-DD'),
                end: date.length > 1 ? moment(date[1]).format('YYYY-MM-DD') : moment(date[0]).format('YYYY-MM-DD'),
                classNames: eventColorLabel.val()
            })
        } else {
            const date = eventDateRange.selectedDates

            editableEvent.setProp('title', titleField.val())
            editableEvent.setExtendedProp('repeatField', repeatField.val())
            editableEvent.setExtendedProp('gestsField', gestsField.value)
            editableEvent.setExtendedProp('eventDescriptionLabel', eventDescriptionLabel.val())
            editableEvent.setExtendedProp('eventLocationLabel', eventLocationLabel.val())
            editableEvent.setProp('classNames', eventColorLabel.val())
            editableEvent.setStart(moment(date[0]).format('YYYY-MM-DD'))
            editableEvent.setEnd(date.length > 1 ? moment(date[1]).format('YYYY-MM-DD') : moment(date[0]).format('YYYY-MM-DD'))
        }
        $('#addEventToCalendarModal').modal('hide')
        filterSearchExample.filter()
    })

    // Set Form
    function prepareData(title, start, end, event = {}) {
        $('#addEventToCalendarModal').modal('show')
        $('#processEvent').text('Save')

        titleField.val(title)
        eventDateRange.setDate([moment(start).format('MM/DD/YYYY'), moment(end).format('MM/DD/YYYY')])

        if (Object.keys(event).length) {
            repeatField.val(event.extendedProps.repeatField)
            repeatField.trigger('change')
            gestsField.addTags(event.extendedProps.gestsField)
            eventDescriptionLabel.val(event.extendedProps.eventDescriptionLabel)
            eventLocationLabel.val(event.extendedProps.eventLocationLabel)
            console.log(eventColorLabel)
            eventColorLabel.val(event.classNames[0])
            eventColorLabel.trigger('change')

            editableEvent = event
        }
    }

    // Clear Form
    function clearForm() {
        titleField.val('')
        eventDescriptionLabel.val('')
        eventLocationLabel.val('')
        repeatField.val('everyday')
        repeatField.trigger('change')
        eventColorLabel.val('hs-team')
        eventColorLabel.trigger('change')
        gestsField.removeAllTags()
        editableEvent = {}

        $('#processEvent').text('Create Event')
    }

    // Filter
    const filterSearchExample = new HSFullcalendarFilter(fullcalendarEditable)

    filterSearchExample.addFilter('byTitle', function (event) {
        return event.title.toLowerCase().indexOf($('#filter-by-title').val().toLowerCase()) !== -1
    })

    filterSearchExample.addFilter('byCategory', function (event) {
        const selectedCategories = $('[data-filter] input:checked')
        if (!selectedCategories.length) return false
        let show = false

        selectedCategories.each(key => {
            if (event.classNames.includes($($(selectedCategories)[key]).val()) || event.extendedProps.forceEvent) {
                show = true
                return false
            }
        })

        return show
    })

    $('#filter-by-title').on('input', function () {
        filterSearchExample.filter()
    })

    $('[data-filter]').on('change', function () {
        filterSearchExample.filter()
    })

    filterSearchExample.filter()


    // ADD DRAGGABLE CLASS FOR CALENDAR
    // =======================================================
    const Draggable = FullCalendar.Draggable;

    new Draggable($('#external-events')[0], {
        itemSelector: '.fc-event'
    });


});