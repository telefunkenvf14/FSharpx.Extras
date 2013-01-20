﻿namespace FSharpx.Collections

/// Heap is like a queue or list data structure, but with an ascending or descending 
/// ordering of the elements. Depending on the ordering head retrieves either the highest or lowest 
/// ordered element in the heap.
/// According to Okasaki the time complexity of the heap functions in this Heap implementation 
/// (based on the "pairing" heap) have "resisted" time complexity analysis. 
[<Class>]
type Heap<'T when 'T : comparison> =

    interface System.Collections.IEnumerable
    interface System.Collections.Generic.IEnumerable<'T>
    interface IPriorityQueue<'T>
        
    ///O(1) worst case. Returns the min or max element.
    member Head : 'T

    ///O(1) worst case. Returns option first min or max element.
    member TryHead : 'T option

    ///O(log n) amortized time. Returns a new heap with the element inserted.
    member Insert : 'T -> Heap<'T>

    ///O(1). Returns true if the heap has no elements.
    member IsEmpty : bool

    ///O(1). Returns true if the heap has max element at head.
    member IsDescending : bool

    ///O(n). Returns the count of elememts.
    member Length : int 

    ///O(log n) amortized time. Returns heap from merging two heaps, both must have same descending.
    member Merge : Heap<'T> -> Heap<'T>

    ///O(log n) amortized time. Returns heap option from merging two heaps.
    member TryMerge : Heap<'T> -> Heap<'T> option

    ///O(log n) amortized time. Returns a new heap of the elements trailing the head.
    member Tail : unit -> Heap<'T>

    ///O(log n) amortized time. Returns option heap of the elements trailing the head.
    member TryTail : unit -> Heap<'T> option

    ///O(log n) amortized time. Returns the head element and tail.
    member Uncons : unit -> 'T * Heap<'T>

    ///O(log n) amortized time. Returns option head element and tail.
    member TryUncons : unit -> ('T * Heap<'T>) option

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Heap =   
    //pattern discriminator
    val (|Cons|Nil|) : Heap<'T> -> Choice<('T * Heap<'T>),unit>
  
    ///O(1). Returns a empty heap.
    [<GeneralizableValue>]
    val empty<'T when 'T : comparison> : bool -> Heap<'T>

    ///O(1) worst case. Returns the min or max element.
    val inline head : Heap<'T> -> 'T

    ///O(1) worst case. Returns option first min or max element.
    val inline tryHead : Heap<'T> -> 'T option

    ///O(log n) amortized time. Returns a new heap with the element inserted.
    val inline insert : 'T -> Heap<'T> -> Heap<'T>

    ///O(1). Returns true if the heap has no elements.
    val inline isEmpty : Heap<'T> -> bool

    ///O(1). Returns true if the heap has max element at head.
    val inline isDescending : Heap<'T> -> bool

    ///O(n). Returns the count of elememts.
    val inline length : Heap<'T> -> int

    ///O(log n) amortized time. Returns heap from merging two heaps, both must have same descending.
    val inline merge : Heap<'T> -> Heap<'T> -> Heap<'T>

    ///O(log n) amortized time. Returns heap option from merging two heaps.
    val inline tryMerge : Heap<'T> -> Heap<'T> -> Heap<'T> option

    ///O(n). Returns heap from the sequence.
    val ofSeq : bool -> seq<'T> -> Heap<'T>

    ///O(log n) amortized time. Returns a new heap of the elements trailing the head.
    val inline tail : Heap<'T> -> Heap<'T>

    ///O(log n) amortized time. Returns option heap of the elements trailing the head.
    val inline tryTail : Heap<'T> -> Heap<'T> option

    ///O(log n) amortized time. Returns the head element and tail.
    val inline uncons : Heap<'T> -> 'T * Heap<'T>

    ///O(log n) amortized time. Returns option head element and tail.
    val inline tryUncons : Heap<'T> -> ('T * Heap<'T>) option

    val monoid<'a when 'a :comparison> : FSharpx.Monoid<Heap<'a>>