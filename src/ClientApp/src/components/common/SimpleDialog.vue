<template>
    <b-modal :id="id" title="Czy na chesz wykonać akcję?" >
        <template v-slot:modal-footer="{ ok, cancel }">
            <b-button size="sm" variant="success" @click="handleOk">
                Tak
            </b-button>
            <b-button size="sm" variant="danger" @click="handleCancel">
                Anuluj
            </b-button>
        </template>
    </b-modal>
</template>

<script lang="ts">
    import {Component, Emit, Prop, Vue} from "vue-property-decorator";

    @Component
    export default class SimpleDialog extends Vue {
        @Prop() id!: string;
        
        handleOk() {
            this.result(true);
        }

        handleCancel() {
            this.result(false);
            this.$bvModal.hide(this.id);
        }

        @Emit()
        result(value: boolean) {
            return value;
        }
    }
</script>