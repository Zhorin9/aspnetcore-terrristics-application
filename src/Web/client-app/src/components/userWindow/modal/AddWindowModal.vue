<template>
    <b-modal
        id="add-window-modal"
        title="Dodanie nowego okna"
        size="xl"
        button-size="sm">

        <form @submit.prevent="">
            <div class="form-groups form-label col-6">
                <label>Nazwa okna</label>
                <input
                    v-model="name"
                    v-validate="'required'"
                    data-vv-as="Nazwa okna"
                    name="new.window.name.modal"
                    class="form-control"
                    :class="{ 'is-invalid': errors.collect('new.window.name.modal').length > 0 }"/>
                <validation-messages :errors-list="errors.collect('new.window.name.modal')"/>
            </div>
            <div class="form-group form-label col-6">
                <label>Opis</label>
                <textarea v-model="description" placeholder="Dodatkowy opis"
                          class="form-control"></textarea>
            </div>
        </form>

        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="ok">
                Zapisz
            </b-button>
            <b-button size="sm" variant="danger" @click="cancel">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script>
    import {GetWindowFormData} from "../../../utils/object-generator";
    import {mapGetters} from "vuex";
    import types from "../../../store/types";

    export default {
        components: {

        },
        computed:{
          ...mapGetters({
          })
        },
        data() {
            return GetWindowFormData();
        },
        methods: {
            ok() {
                this.resetData();
            },
            cancel() {
                this.resetData();
            },
            resetData() {
                Object.assign(this.$data, GetWindowFormData());
            }
        }
    }
</script>

<style scoped>

</style>
