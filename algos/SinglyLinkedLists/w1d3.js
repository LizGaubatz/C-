// class Node {
//     /**
//      * Constructs a new Node instance. Executed when the 'new' keyword is used.
//      * @param {any} data The data to be added into this new instance of a Node.
//      *    The data can be anything, just like an array can contain strings,
//      *    numbers, objects, etc.
//      * @returns {Node} A new Node instance is returned automatically without
//      *    having to be explicitly written (implicit return).
//      */
//     constructor(data) {
//         this.data = data;
//         /**
//          * This property is used to link this node to whichever node is next
//          * in the list. By default, this new node is not linked to any other
//          * nodes, so the setting / updating of this property will happen sometime
//          * after this node is created.
//          */
//         this.next = null;
//     }
// }

// /**
//  * Class to represent a list of linked nodes. Nodes CAN be linked together
//  * without this class to form a linked list, but this class helps by providing
//  * a place to keep track of the start node (head) of the list at all times and
//  * as a place to add methods (functions inside an object) so that every new
//  * linked list that is instantiated will inherit helpful the same helpful
//  * methods, just like every array you create inherits helpful methods.
//  */
// class SinglyLinkedList {
//     /**
//      * Constructs a new instance of an empty linked list that inherits all the
//      * methods.
//      * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
//      *    returned without having to explicitly write "return".
//      */
//     constructor() {
//         this.head = null;
//     }

//     /*
//     Pseudocode:
//     create a method that returns the data for the final node, and removes that node
//     create a runner
//     run up until runner.next.next == null
//     hold runner.next.data in a temp
//     set runner.next to null
//     return temp
//     */
//     /**
//      * Removes the last node of this list.
//      * - Time: O(?).
//      * - Space: O(?).
//      * @returns {any} The data from the node that was removed.
//      */
//     removeBack() {
//         const runner = this.head
//         while (runner.next.next != null) {
//             runner = runner.next
//         }
//         const temp = runner.next.data
//         runner.next = null
//         return temp
//     }

//     /**
//      * Determines whether or not the given search value exists in this list.
//      * - Time: O(?).
//      * - Space: O(?).
//      * @param {any} val The data to search for in the nodes of this list.
//      * @returns {boolean}
//      */
//     contains(val) {
//         /*
//                 create a function that takes in a search value, and a node
//                 check if current.data is equal to the search value
//                 if it is then return true
//                 else if current.next is null return false
//                 return containsRecursive(val, current.next)
//             */
//         containsRecursive(val, current = this.head) {
//             if (current.data == val) return true
//             else if (current.next == null) return false
//             return this.containsRecursive(val, current.next)
//         }


//         /**
//          * Determines whether or not the given search value exists in this list.
//          * - Time: O(?).
//          * - Space: O(?).
//          * @param {any} val The data to search for in the nodes of this list.
//          * @param {?node} current The current node during the traversal of this list
//          *    or null when the end of the list has been reached.
//          * @returns {boolean}
//          */
//         containsRecursive(val, current = this.head) {
//             if (current.data == val) return true
//             else if (current.next == null) return false
//             return this.containsRecursive(val, current.next)
//         }


//         /**
//          * Creates a new node with the given data and inserts that node at the front
//          * of the list.
//          * - Time: O(1) constant.
//          * - Space: O(1) constant.
//          * @param {any} data The data for the new node.
//          * @returns {SinglyLinkedList} This list.
//          */
//         insertAtFront(data) {
//             const newHead = new Node(data);
//             newHead.next = this.head;
//             this.head = newHead;
//             return this;
//         }

//         /**
//          * Removes the first node of this list.
//          * - Time: O(1) constant.
//          * - Space: O(1) constant.
//          * @returns {any} The data from the removed node.
//          */
//     }
// }




/**
 * Class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class Node {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {Node} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */
    constructor(data) {
        this.data = data;
        /**
         * This property is used to link this node to whichever node is next
         * in the list. By default, this new node is not linked to any other
         * nodes, so the setting / updating of this property will happen sometime
         * after this node is created.
         */
        this.next = null;
    }
}

/**
 * Class to represent a list of linked nodes. Nodes CAN be linked together
 * without this class to form a linked list, but this class helps by providing
 * a place to keep track of the start node (head) of the list at all times and
 * as a place to add methods (functions inside an object) so that every new
 * linked list that is instantiated will inherit helpful the same helpful
 * methods, just like every array you create inherits helpful methods.
 */
class SinglyLinkedList {
    /**
     * Constructs a new instance of an empty linked list that inherits all the
     * methods.
     * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
     *    returned without having to explicitly write "return".
     */
    constructor() {
        this.head = null;
    }

    /**
     * Removes the last node of this list.
     * - Time: O(n) linear, n = length of list.
     * - Space: O(1) constant.
     * @returns {any} The data from the node that was removed.
     */
    removeBack() {
        if (this.isEmpty()) {
            return null;
        }

        // Only 1 node.
        if (this.head.next === null) {
            return this.removeHead();
        }

        // More than 1 node.
        let runner = this.head;

        while (runner.next.next) {
            runner = runner.next;
        }

        // after while loop finishes, runner is now at 2nd to last node
        const removedData = runner.next.data;
        runner.next = null; // remove it from list
        return removedData;
    }

    /**
     * This version uses more conditions instead of more returns. It is a good
     * example of how more returns can make the code easier to read and cleaner.
     * Removes the last node of this list.
     * - Time: O(n) linear, n = length of list.
     * - Space: O(1) constant.
     * @returns {any} The data from the node that was removed.
     */
    removeBack2() {
        let removedData = null;

        if (!this.isEmpty()) {
            if (this.head.next === null) {
                // head only node
                removedData = this.removeHead();
            } else {
                let runner = this.head;
                // right of && will only be checked if left is true
                while (runner.next && runner.next.next) {
                    runner = runner.next;
                }

                // after while loop finishes, runner is now at 2nd to last node
                removedData = runner.next.data;
                runner.next = null; // remove it from list
            }
        }
        return removedData;
    }

    /**
     * Determines whether or not the given search value exists in this list.
     * - Time: O(n) linear, n = length of list.
     * - Space: O(1) constant.
     * @param {any} val The data to search for in the nodes of this list.
     * @returns {boolean}
     */
    contains(val) {
        let runner = this.head;

        while (runner) {
            if (runner.data === val) {
                return true;
            }
            runner = runner.next;
        }
        return false;
    }

    /**
     * Determines whether or not the given search value exists in this list.
     * - Time: O(n) linear, n = length of list.
     * - Space: O(n) linear due to the call stack.
     * @param {any} val The data to search for in the nodes of this list.
     * @param {?node} current The current node during the traversal of this list
     *    or null when the end of the list has been reached.
     * @returns {boolean}
     */
    containsRecursive(val, current = this.head) {
        if (current === null) {
            return false;
        }
        if (current.data === val) {
            return true;
        }
        return this.containsRecursive(val, current.next);
    }
}


/******************************************************************* 
Multiple test lists already constructed to test your methods on.
Below commented code depends on insertAtBack method to be completed,
after completing it, uncomment the code.
*/
