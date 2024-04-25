import { createSlice } from "@reduxjs/toolkit";




const initialState = {
    isVisibleAddWorkingSpace: false,
    isVisibleAddTask: true,
    isVisibleAssignUser: false
}


const toggleComponentSlice = createSlice({
    name: 'togglecomponent',
    initialState,
    reducers: {
        toggleComponentVisibility: (state, action) => {
            const { componentName } = action.payload;
            if (   state[`isVisible${componentName}`] != true) {
                state[`isVisible${componentName}`] = !state[`isVisible${componentName}`]
            }
            

            Object.keys(state).forEach(key => {
              
                if (key !== `isVisible${componentName}`) {
                  state[key] = false
                }
              })
        }
    }
})

export const { toggleComponentVisibility } = toggleComponentSlice.actions

export default toggleComponentSlice.reducer