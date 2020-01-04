<template>
    <div id="plus-component"
         class="m-5 p-5 font-awesome-transparent cursor-pointer"
         @click="onClick">
        <font-awesome-icon :icon="['fas', 'plus']" size="10x"/>

        <b-tooltip target="plus-component" placement="top">
            <strong>Dodaj nowy czujnik</strong>
        </b-tooltip>
    </div>
</template>

<script lang="ts">
    import {Component, Emit, Vue} from "vue-property-decorator";

    @Component
    export default class PlusComponent extends Vue {
        
        @Emit('add-new-element')
        onClick() {
            return true;
        }
    }
</script>

<style scoped>
    .font-awesome-transparent {
        border: 3px solid;
        color: #ffffff69;
        margin: auto;
        text-align: center;
        vertical-align: middle;
    }
</style>