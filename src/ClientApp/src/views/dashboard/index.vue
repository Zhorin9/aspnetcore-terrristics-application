<template>
  <div class="dashboard-container">
    <div class="dashboard-text">
      name:{{ email }}
    </div>
    <div class="dashboard-text">
      roles:
      <span v-for="role in roles" :key="role">{{ role }}</span>
    </div>
  </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
import {UserModule} from '@/store/modules/user'

@Component
export default class extends Vue {
  get email() {
    return UserModule.email
  }

  get roles() {
    return UserModule.roles
  }
}
</script>

<style lang="scss" scoped>
.dashboard {
  &-container {
    margin: 30px;
  }

  &-text {
    font-size: 30px;
    line-height: 46px;
  }
}
</style>
