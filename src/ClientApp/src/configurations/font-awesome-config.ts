// https://github.com/FortAwesome/vue-fontawesome
import Vue from 'vue';

import {library} from '@fortawesome/fontawesome-svg-core';
import {faPlus, faLightbulb, faFrog, faCircleNotch, faSync} from '@fortawesome/free-solid-svg-icons';
import {FontAwesomeIcon} from '@fortawesome/vue-fontawesome';

// Register vue font awesome component globally 
Vue.component('font-awesome-icon', FontAwesomeIcon);

// Install icons
library.add(faPlus);
library.add(faLightbulb);
library.add(faFrog);
library.add(faCircleNotch);
library.add(faSync);
