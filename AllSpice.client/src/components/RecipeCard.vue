<template>
  <div data-bs-target="#instructModal" data-bs-toggle="modal">
    <div class="p-2">
      <h3 class="text-success">{{ recipe.title }}</h3>
      <h6 class="text-dark">{{ recipe.subTitle }}</h6>
    </div>
    <img class="img-fluid" :src="recipe.picture" alt="" />
  </div>
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