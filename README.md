# LightyLibUnity
Lighty's library for unity.

## Automachine

This a namespace for FSM (Finate State Machine) support.

### NonReflective

A old-fashin state machine. Using integers as state index and arrange them in a list.

### Reflective

Use reflection mechanics for a quicker and more flexible automachine build.

There are few attributes for marking functions as Entry, Transfer, Exit. Those attributes require a string parameter for initialization, which is the state that this function will be called.

The Transfer Function should always return a string to indicate the state for next update. If the return value equals to the current state name then it won't transfer between states.

A difference between reflective and non-reflective automachine is that, in the reflective automachine, the function will be called in the order of Transfer, Exit, Entry. Instead of Exit, Transfer, Entry in non-reflective one.

The reason is that all transfer conditions and transfer actions are included in the transfer function. As it determines whether to transfer between states, it has to be called before exit function.

I will not fix this feature until I found it so crap that even I can't stand. So good luck programming :smile: