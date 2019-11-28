<template>
    <footer class="footer-green"/>
</template>
<script lang="ts">
    import {Component, Vue} from "vue-property-decorator";

    @Component({})

    export default class Footer extends Vue {
    }
</script>

<style scoped>
    .footer-green {
        position: fixed;
        width: 100%;
        min-height: 400px;
    }
</style>
