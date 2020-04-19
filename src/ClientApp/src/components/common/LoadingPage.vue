<template>
    <font-awesome-icon :icon="['fas', 'circle-notch']" :size="sizeClass" spin/>
</template>

<script lang="ts">
    import {Component, Prop, Vue} from "vue-property-decorator";

    @Component
    export default class LoadingPage extends Vue {
        @Prop({default: 1}) size!: number | undefined;

        get sizeClass() {
            return this.size + 'x';
        }
    }
</script>