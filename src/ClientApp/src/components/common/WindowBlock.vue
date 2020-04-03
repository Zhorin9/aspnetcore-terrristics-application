<template>
    <div class="m-3">
        <b-card class="card-green" :title="data.Name" :img-src="iconUrl" img-alt="Image" img-top>
            <b-card-text algin="left">
                {{data.Description}}
                <div class="mt-5">
                    <b-button :to="{name: 'terraristicsData', params:{id: data.Id}}"
                              class="ml-1"
                              variant="info"
                              size="sm">
                        Podgląd
                    </b-button>
                    <b-button class="ml-1" size="sm" @click="editTerraristicsWindow">
                        Edytuj
                    </b-button>
                    <b-button class="ml-1" variant="danger" size="sm" @click="deleteTerraristicsWindow">
                        Usuń
                    </b-button>
                </div>
            </b-card-text>
            <template v-slot:footer>
                <small class="text-muted">Data utworzenia: {{data.CreationDate | moment('YYYY-MM-DD')}} </small>
            </template>
        </b-card>
    </div>
</template>

<script lang="ts">
    import {Component, Emit, Prop, Vue} from "vue-property-decorator";

    @Component
    export default class WindowBlock extends Vue {
        @Prop() data: TerraristicsWindowModel | undefined;

        //TODO do webpacka
        get iconUrl() {
            return require('@/assets/homeBackground.jpg')
        }

        get terraristicsWindowId() {
            if (this.data) {
                return this.data.Id;
            }
            return null;
        }

        @Emit()
        editTerraristicsWindow() {
            return this.terraristicsWindowId;
        }

        @Emit()
        deleteTerraristicsWindow() {
            return this.terraristicsWindowId;
        }
    }
</script>

<style scoped>
    .btn-sm {
        padding: 0.25rem 0.5rem;
        font-size: 0.75rem;
        line-height: 1.5;
        border-radius: 0.2rem;
    }
</style>
