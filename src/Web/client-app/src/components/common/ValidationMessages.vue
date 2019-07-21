<template>
    <ul>
        <li v-for="(error, index) in errorsList" :key="index">
            {{error}}
        </li>
    </ul>
</template>

<script>
    export default {
        name: "ValidationMessage",
        props: ["errorsList"],
    }
</script>

<style scoped>
    ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        font-size: 0.8em;
        color: #b42424;
    }
</style>
