<template>
    <div>
        <div class="ownerProf">
            <div class="profIcon d-flex">

                <button class="btn btn-dark ml-auto rnd" @click=logout()>Logout</button>
            </div>
            <h1 class="title">Hello {{user.username}}</h1>
        </div>
    </div>
</template>

<script>
    import router from '../router'
    export default {
        name: 'UserProfile',
        data() {
            return {
                newuser: {
                    id: '',
                    username: '',
                    email: '',
                    password: ''
                }
            }
        },
        mounted() {
            if (!this.$store.state.user._id) {
                router.push({ name: 'Home' })
            }
        },
        computed: {
            user() {
                return this.$store.state.user;
            }
        },
        methods: {}
    }




</script>

<style>
</style>