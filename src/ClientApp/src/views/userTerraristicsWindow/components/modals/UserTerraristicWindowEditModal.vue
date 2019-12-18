<template>
    <b-modal
            id="user-window-edit-modal"
            title="Edycja okna"
            size="lg"
            button-size="sm"
            ref="addUserTerraristicWindowModal">
        <div v-show="failedOnCreate" class="alert alert-danger text-center modal-alert"
             :style="`padding: 0`">
            <p class="text-danger" :style="`font-size: 16px; margin-bottom:0px;`">Nie udało się
                zapisać okna, spróbuj ponownie :(</p>
        </div>
        <form v-if="!waitingForResponse"
              @submit.prevent="handleOk">
            <div class="form-groups form-label col-6">
                <label>Nazwa okna</label>
                <input v-model="name"
                       data-vv-as="Nazwa okna"
                       name="user-window-add-modal-name"
                       class="form-control"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="description"
                          placeholder="Dodatkowy opis"
                          class="form-control">
                </textarea>
            </div>
        </form>
        <template v-else>
            <loading-page/>
        </template>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="resetModalDataAndGoToCreatedWindow">
                Anuluj
            </b-button>
        </template>
    </b-modal>
    <b-modal
            id="addWindowModal"
            title="Edycja danych na temat terrarium"
            lazy="false">

        <p>BLA BLA BLA </p>

    </b-modal>
</template>

<script lang="ts">
    import {Component, PropSync, Vue} from "vue-property-decorator";

    @Component
    export default class UserTerraristicWindowEditModal extends Vue {
        @PropSync('name', {type: String}) syncedName!: string;
        @PropSync('description', {type: String}) syncedDescription!: string;
    }
</script>