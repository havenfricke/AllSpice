<template>
  <div>{{ recipe.title }}</div>
</template>

<script>
export default {
  props: {
    recipe: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>

<style>
</style>