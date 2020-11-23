<template>
    <b-modal :id="id" :title="title" >
        <p>
            {{description}}
        </p>
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
        @Prop({default: "Czy na chesz wykonać akcję?"}) title!: string;
        @Prop({default: ""}) description!: string;
        
        handleOk() {
            this.modalResult(true);
            // this.$bvModal.hide(this.id);
        }

        handleCancel() {
            // this.$bvModal.hide(this.id);
        }

        @Emit()
        modalResult(value: boolean) {
            return value;
        }
    }
</script>